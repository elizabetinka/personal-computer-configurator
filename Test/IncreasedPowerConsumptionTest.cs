using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerBuilder;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class IncreasedPowerConsumptionTest
{
    private DataBase _dataBase;
    private ComputerComponentsFactory _componentsFactory;
    private ComputerConsistentDirector _consistentDirector;
    private ComputerConsistentBuilder _consistentBuilder;
    private IOrdinaryComputerBuilder _ordinaryBuilder;
    private Computer _defoultComputer;

    private Cpu cpu;
    private Gpu gpu;
    private Hdd hdd;
    private Ram ram;
    private PowerSupply powerSupply;
    private WiFiAdapter wiFiAdapter;
    private CpuBuilder _cpuBuilder = new CpuBuilder();
    private GpuBuilder _gpuBuilder = new GpuBuilder();
    private HddBuilder _hddBuilder = new HddBuilder();
    private RamBuilder _ramBuilder = new RamBuilder();
    private PowerSupplyBuilder _powerSupplyBuilder = new PowerSupplyBuilder();
    private WiFiAdapterBuilder _wiFiAdapteBuilder = new WiFiAdapterBuilder();
    public IncreasedPowerConsumptionTest()
    {
        _dataBase = new DataBase();
        _componentsFactory = new ComputerComponentsFactory(
            new Factory<Cpu>(_dataBase.CpuList),
            new Factory<CpuCoolingSystem>(_dataBase.CpuCoolingSystemList),
            new Factory<Ram>(_dataBase.RamList),
            new Factory<Ssd>(_dataBase.SsdList),
            new Factory<Hdd>(_dataBase.HddList),
            new Factory<Gpu>(_dataBase.GpuList),
            new Factory<PowerSupply>(_dataBase.PowerSuppluList),
            new Factory<ComputerCase>(_dataBase.ComuterCaseList),
            new Factory<MotherBoard>(_dataBase.MotherBoardsList),
            new Factory<WiFiAdapter>(_dataBase.WiFiAdapterList));

        cpu = _componentsFactory.CreateCpuByName("AMD Ryzen 5 5500") ?? throw new ArgumentNullException(nameof(Cpu));
        gpu = _componentsFactory.CreateGpuByName("Palit GeForce GTX 1660 SUPER GamingPro") ?? throw new ArgumentNullException(nameof(Gpu));
        hdd = _componentsFactory.CreateHddByName("Seagate BarraCuda") ?? throw new ArgumentNullException(nameof(Hdd));
        ram = _componentsFactory.CreateRamByName("Kingston FURY Beast") ?? throw new ArgumentNullException(nameof(Ram));
        powerSupply = _componentsFactory.CreatePowerSupplyByName("Cougar STX 700W") ?? throw new ArgumentNullException(nameof(PowerSupply));
        wiFiAdapter = _componentsFactory.CreateWiFiAdapterByName("TP-LINK Archer T5E") ?? throw new ArgumentNullException(nameof(WiFiAdapter));

        _consistentDirector = new ComputerConsistentDirector();
        _consistentBuilder = new ComputerConsistentBuilder();
        _ordinaryBuilder = new OrdinaryComputerBuilder();
        _defoultComputer = _consistentDirector.Direct("GIGABYTE B550 AORUS ELITE V2", "AMD Ryzen 5 5500", "LIAN LI Galahad AIO 360", "Kingston FURY Beast", "Cougar Duoface Pro RGB", "Cougar STX 700W", null, "Seagate BarraCuda", "Palit GeForce GTX 1660 SUPER GamingPro", "TP-LINK Archer T5E", _componentsFactory).Build();
    }

    [Theory]
    [InlineData(1, 1, 1, 1, 1, 50)]
    [InlineData(5, 5, 5, 5, 5, 50)]
    [InlineData(10, 10, 10, 10, 10, 50)]
    [InlineData(30, 5, 5, 1.5, 1, 50)]
    public void ChangePowerConsumptionTestValid(int cpuV, int ramV, int gpuV, int addtionalMemoryV, int wiFiAdapteV, int powerSupplyV)
    {
        // Arrang
        cpu = cpu.Direct(_cpuBuilder).WithPowerConsumption(cpuV).Build();
        gpu = gpu.Direct(_gpuBuilder).WithPowerConsumption(gpuV).Build();
        ram = ram.Direct(_ramBuilder).WithPowerConsumption(ramV).Build();
        hdd = hdd.Direct(_hddBuilder).WithPowerConsumption(addtionalMemoryV).Build();
        wiFiAdapter = wiFiAdapter.Direct(_wiFiAdapteBuilder).WithPowerConsumption(wiFiAdapteV).Build();
        powerSupply = powerSupply.Direct(_powerSupplyBuilder).WithPeakLoad(powerSupplyV).Build();

        // Act
        _defoultComputer = _defoultComputer.Debuilder(_ordinaryBuilder).WithCpu(cpu).WithGpu(gpu).WithRam(ram).WithAdditionalMemory(hdd).WithWiFiAdapter(wiFiAdapter).WithPowerSupply(powerSupply).Build();

        // Assert
        Assert.Equal(ComputerStatus.Good, _defoultComputer.ResultStatus.ComputerStatus);
    }

    [Theory]
    [InlineData(1, 1, 1, 1, 1, 3)]
    [InlineData(5, 5, 5, 5, 5, 10)]
    [InlineData(10, 10, 10, 10, 10, 49)]
    [InlineData(30, 5, 5, 1.5, 1, 25.5)]
    public void ChangePowerConsumptionTestNoValid(int cpuV, int ramV, int gpuV, int addtionalMemoryV, int wiFiAdapteV, int powerSupplyV)
    {
        // Arrang
        cpu = cpu.Direct(_cpuBuilder).WithPowerConsumption(cpuV).Build();
        gpu = gpu.Direct(_gpuBuilder).WithPowerConsumption(gpuV).Build();
        ram = ram.Direct(_ramBuilder).WithPowerConsumption(ramV).Build();
        hdd = hdd.Direct(_hddBuilder).WithPowerConsumption(addtionalMemoryV).Build();
        wiFiAdapter = wiFiAdapter.Direct(_wiFiAdapteBuilder).WithPowerConsumption(wiFiAdapteV).Build();
        powerSupply = powerSupply.Direct(_powerSupplyBuilder).WithPeakLoad(powerSupplyV).Build();

        // Act
        _defoultComputer = _defoultComputer.Debuilder(_ordinaryBuilder).WithCpu(cpu).WithGpu(gpu).WithRam(ram).WithAdditionalMemory(hdd).WithWiFiAdapter(wiFiAdapter).WithPowerSupply(powerSupply).Build();

        // Assert
        Assert.Equal(ComputerStatus.IncreasedPowerConsumption, _defoultComputer.ResultStatus.ComputerStatus);
    }
}