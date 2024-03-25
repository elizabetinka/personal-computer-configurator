using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerBuilder;

public class OrdinaryComputerBuilder : IOrdinaryComputerBuilder
{
    private readonly IComputerConsistentBuilder _builder = new ComputerConsistentBuilder();
    private Cpu? _cpu;
    private MotherBoard? _motherBoard;
    private Gpu? _gpu;
    private IAdditionalMemory? _additionalMemory;
    private ComputerCase? _computerCase;
    private WiFiAdapter? _wiFiAdapter;
    private PowerSupply? _powerSupply;
    private CpuCoolingSystem? _cpuCoolingSystem;
    private Ram? _ram;

    public Computer Build()
    {
        _motherBoard = _motherBoard ?? throw new ArgumentException("MotherBoard");
        _cpu = _cpu ?? throw new ArgumentException("Cpu");
        _cpuCoolingSystem = _cpuCoolingSystem ?? throw new ArgumentException("CpuCoolingSystem");
        _ram = _ram ?? throw new ArgumentException("Ram");
        _computerCase = _computerCase ?? throw new ArgumentException("ComputerCase");
        _additionalMemory = _additionalMemory ?? throw new ArgumentException("AdditionalMemory");
        _powerSupply = _powerSupply ?? throw new ArgumentException("PowerSupply");

        return _builder
            .WithMotherBoard(_motherBoard)
            .WithCpu(_cpu)
            .WithCpuCoolingSystem(_cpuCoolingSystem)
            .WithRam(_ram)
            .WithComputerCase(_computerCase)
            .WithAdditionalMemory(_additionalMemory)
            .YouCanAddGpu(_gpu)
            .WithPowerSupply(_powerSupply)
            .YouCanAddWiFiAdapter(_wiFiAdapter)
            .Build();
    }

    public IOrdinaryComputerBuilder WithCpu(Cpu cpu)
    {
        _cpu = cpu;
        return this;
    }

    public IOrdinaryComputerBuilder WithMotherBoard(MotherBoard motherBoard)
    {
        _motherBoard = motherBoard;
        return this;
    }

    public IOrdinaryComputerBuilder WithCpuCoolingSystem(CpuCoolingSystem cpuCoolingSystem)
    {
        _cpuCoolingSystem = cpuCoolingSystem;
        return this;
    }

    public IOrdinaryComputerBuilder WithRam(Ram ram)
    {
        _ram = ram;
        return this;
    }

    public IOrdinaryComputerBuilder WithAdditionalMemory(IAdditionalMemory additionalMemory)
    {
        _additionalMemory = additionalMemory;
        return this;
    }

    public IOrdinaryComputerBuilder WithGpu(Gpu? gpu)
    {
        _gpu = gpu;
        return this;
    }

    public IOrdinaryComputerBuilder WithComputerCase(ComputerCase computerCase)
    {
        _computerCase = computerCase;
        return this;
    }

    public IOrdinaryComputerBuilder WithPowerSupply(PowerSupply powerSupply)
    {
        _powerSupply = powerSupply;
        return this;
    }

    public IOrdinaryComputerBuilder WithWiFiAdapter(WiFiAdapter? wiFiAdapter)
    {
        _wiFiAdapter = wiFiAdapter;
        return this;
    }
}