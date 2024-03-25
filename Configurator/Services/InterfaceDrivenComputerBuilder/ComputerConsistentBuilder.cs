using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerConsistentBuilder : IComputerConsistentBuilder
{
    private Cpu? _cpu;
    private MotherBoard? _motherBoard;
    private Gpu? _gpu;
    private IAdditionalMemory? _additionalMemory;
    private ComputerCase? _computerCase;
    private WiFiAdapter? _wiFiAdapter;
    private PowerSupply? _powerSupply;
    private CpuCoolingSystem? _cpuCoolingSystem;
    private Ram? _ram;

    private double _currentPowerConsumption;
    private ComputerResultStatus _resultStatus = new(ComputerStatus.Good);
    private int _unusedSataCount;
    private IDictionary<int, int>? _unusedPciELinesCounts = new Dictionary<int, int>(5);

    public Computer Build()
    {
        return new Computer(
            _cpu ?? throw new ArgumentNullException(nameof(_cpu)),
            _motherBoard ?? throw new ArgumentNullException(nameof(_motherBoard)),
            _cpuCoolingSystem ?? throw new ArgumentNullException(nameof(_cpuCoolingSystem)),
            _ram ?? throw new ArgumentNullException(nameof(_ram)),
            _computerCase ?? throw new ArgumentNullException(nameof(_computerCase)),
            _additionalMemory ?? throw new ArgumentNullException(nameof(_additionalMemory)),
            _powerSupply ?? throw new ArgumentNullException(nameof(_powerSupply)),
            _gpu,
            _wiFiAdapter,
            _resultStatus.Clone());
    }

    public ICpuCoolingSystemBuilder WithCpu(Cpu cpu)
    {
        cpu = cpu ?? throw new ArgumentNullException(nameof(cpu));
        _motherBoard = _motherBoard ?? throw new ArgumentException("MotherBoard");
        if (_motherBoard.Socket != cpu.Socket || !_motherBoard.IsSupportCpu(cpu))
        {
            _resultStatus.ComputerStatus = ComputerStatus.NotWork;
            _resultStatus.AddProblemLogs("Cpu");
        }

        _cpu = cpu;
        _currentPowerConsumption += _cpu.PowerConsumption;
        return this;
    }

    public ICpuBuilder WithMotherBoard(MotherBoard motherBoard)
    {
        _motherBoard = motherBoard;
        _unusedSataCount = _motherBoard.SataPortsCounts;
        _unusedPciELinesCounts = _motherBoard.PciELinesCounts.ToDictionary(entry => entry.Key, entry => entry.Value);
        return this;
    }

    public IRamBuilder WithCpuCoolingSystem(CpuCoolingSystem cpuCoolingSystem)
    {
        cpuCoolingSystem = cpuCoolingSystem ?? throw new ArgumentNullException(nameof(cpuCoolingSystem));
        _cpu = _cpu ?? throw new ArgumentException("CPU");

        if (_cpu.Tdp > cpuCoolingSystem.Tdp)
        {
            _resultStatus.ComputerStatus = ComputerStatus.Disclaimer;
        }

        if (!cpuCoolingSystem.IsSocketSupport(_cpu.Socket))
        {
            _resultStatus.ComputerStatus = ComputerStatus.NotWork;
            _resultStatus.AddProblemLogs("Cpu Cooling System");
        }

        _cpuCoolingSystem = cpuCoolingSystem;
        return this;
    }

    public IComputerCaseBuilder WithRam(Ram ram)
    {
        ram = ram ?? throw new ArgumentNullException(nameof(ram));
        _motherBoard = _motherBoard ?? throw new ArgumentException("MotherBoard");
        _cpu = _cpu ?? throw new ArgumentException("CPU");

        if (_motherBoard.GetMinUsefulFrequencie() > ram.GetMaxUsefulFrequencie() || _motherBoard.Ddr != ram.Ddr)
        {
            _resultStatus.ComputerStatus = ComputerStatus.NotWork;
            _resultStatus.AddProblemLogs("Ram");
        }

        if (ram.IsSupportedXMP())
        {
            if (!_motherBoard.IsSupportedXMP() || _cpu.MemoryFrequencie < ram.GetMinUsefulXMPFrequencie())
            {
                _resultStatus.ComputerStatus = ComputerStatus.NotWork;
                _resultStatus.AddProblemLogs("RamXMP");
            }
        }

        _ram = ram;
        _currentPowerConsumption += ram.PowerConsumption;
        return this;
    }

    public IGpuBuilder WithAdditionalMemory(IAdditionalMemory additionalMemory)
    {
        additionalMemory = additionalMemory ?? throw new ArgumentNullException(nameof(additionalMemory));
        switch (additionalMemory.Connection)
        {
            case ConnectionOption.Sata:
                if (_unusedSataCount > 0)
                {
                    --_unusedSataCount;
                }
                else
                {
                    _resultStatus.ComputerStatus = ComputerStatus.NotWork;
                    _resultStatus.AddProblemLogs("Additional Memory connection");
                }

                break;
            case ConnectionOption.PciE:
                if (!CanIUsePcieEForAdditionMemory())
                {
                    _resultStatus.ComputerStatus = ComputerStatus.NotWork;
                    _resultStatus.AddProblemLogs("Additional Memory connection");
                }

                break;
        }

        _additionalMemory = additionalMemory;
        _currentPowerConsumption += additionalMemory.PowerConsumption;
        return this;
    }

    public IPowerSupplyBuilder YouCanAddGpu(Gpu? gpu)
    {
        _cpu = _cpu ?? throw new ArgumentException("CPU");
        if (gpu is null)
        {
            if (!_cpu.Gpu)
            {
                _resultStatus.ComputerStatus = ComputerStatus.NotWork;
                _resultStatus.AddProblemLogs("Without GPU");
                return this;
            }

            return this;
        }

        _gpu = gpu;
        if (!CanIUsePcieEForGpu())
        {
            _resultStatus.ComputerStatus = ComputerStatus.NotWork;
            _resultStatus.AddProblemLogs("GPU Connection problem");
            return this;
        }

        _currentPowerConsumption += gpu.PowerConsumption;
        return this;
    }

    public IAdditionalMemoryBuilder WithComputerCase(ComputerCase computerCase)
    {
        computerCase = computerCase ?? throw new ArgumentNullException(nameof(computerCase));
        _motherBoard = _motherBoard ?? throw new ArgumentException("MotherBoard");
        _cpuCoolingSystem = _cpuCoolingSystem ?? throw new ArgumentException("CpuCoolingSystem");
        if (!computerCase.IsSupportMotherFormFactor(_motherBoard.FormFactor) || computerCase.MaxCpuCoolingHeight < _cpuCoolingSystem.Dimensions.Height)
        {
            _resultStatus.ComputerStatus = ComputerStatus.NotWork;
            _resultStatus.AddProblemLogs("Computer Case");
        }

        _computerCase = computerCase;
        return this;
    }

    public IComputerConsistentBuilder WithPowerSupply(PowerSupply powerSupply)
    {
        powerSupply = powerSupply ?? throw new ArgumentNullException(nameof(powerSupply));
        if (powerSupply.PeakLoad < _currentPowerConsumption)
        {
            _resultStatus.ComputerStatus = ComputerStatus.IncreasedPowerConsumption;
        }

        _powerSupply = powerSupply;
        return this;
    }

    public IComputerConsistentBuilder YouCanAddWiFiAdapter(WiFiAdapter? wiFiAdapter)
    {
        if (wiFiAdapter is null)
        {
            return this;
        }

        _motherBoard = _motherBoard ?? throw new ArgumentException("MotherBoard");
        if (_motherBoard.WiFiModul)
        {
            _resultStatus.ComputerStatus = ComputerStatus.NotWork;
            _resultStatus.AddProblemLogs("WiFi Adapter");
            return this;
        }

        _wiFiAdapter = wiFiAdapter;
        _currentPowerConsumption += wiFiAdapter.PowerConsumption;
        _powerSupply = _powerSupply ?? throw new ArgumentException("powerSupply");
        WithPowerSupply(_powerSupply);
        return this;
    }

    private bool CanIUsePcieEForAdditionMemory()
    {
        _unusedPciELinesCounts = _unusedPciELinesCounts ?? throw new ArgumentException("PciELinesCounts");
        if (_unusedPciELinesCounts[4] > 0)
        {
            --_unusedPciELinesCounts[4];
        }
        else if (_unusedPciELinesCounts[8] > 0)
        {
            --_unusedPciELinesCounts[8];
        }
        else if (_unusedPciELinesCounts[16] > 0)
        {
            --_unusedPciELinesCounts[16];
        }
        else
        {
            return false;
        }

        return true;
    }

    private bool CanIUsePcieEForGpu()
    {
        _unusedPciELinesCounts = _unusedPciELinesCounts ?? throw new ArgumentException("PciELinesCounts");
        if (_unusedPciELinesCounts[16] > 0)
        {
            --_unusedPciELinesCounts[16];
        }
        else
        {
            return false;
        }

        return true;
    }
}