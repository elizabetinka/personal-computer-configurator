using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerBuilder;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class CpuWithCoolingTdpTest
{
    private DataBase _dataBase;
    private ComputerComponentsFactory _componentsFactory;
    private ComputerConsistentDirector _consistentDirector;
    private IOrdinaryComputerBuilder _ordinaryBuilder;
    private Computer _defoultComputer;

    private Cpu cpu;
    private CpuCoolingSystem cpuCoolingSystem;

    private CpuBuilder _cpuBuilder = new CpuBuilder();
    private CpuCoolingSystemBuilder _cpuCoolingSystemBuilder = new CpuCoolingSystemBuilder();

    public CpuWithCoolingTdpTest()
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
        cpuCoolingSystem = _componentsFactory.CreateCpuCoolingSystemByName("LIAN LI Galahad AIO 360") ?? throw new ArgumentNullException(nameof(CpuCoolingSystem));

        _consistentDirector = new ComputerConsistentDirector();
        _ordinaryBuilder = new OrdinaryComputerBuilder();
        _defoultComputer = _consistentDirector.Direct("GIGABYTE B550 AORUS ELITE V2", "AMD Ryzen 5 5500", "LIAN LI Galahad AIO 360", "Kingston FURY Beast", "Cougar Duoface Pro RGB", "Cougar STX 700W", null, "Seagate BarraCuda", "Palit GeForce GTX 1660 SUPER GamingPro", "TP-LINK Archer T5E", _componentsFactory).Build();
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(5, 6)]
    [InlineData(10, 20)]
    [InlineData(30, 35)]
    public void ChangePowerConsumptionTestValid(int cpuTdp, int cpuCoolingTdp)
    {
        // Arrang
        cpu = cpu.Direct(_cpuBuilder).WithTdp(cpuTdp).Build();
        cpuCoolingSystem = cpuCoolingSystem.Direct(_cpuCoolingSystemBuilder).WithTdp(cpuCoolingTdp).Build();

        // Act
        _defoultComputer = _defoultComputer.Debuilder(_ordinaryBuilder).WithCpu(cpu).WithCpuCoolingSystem(cpuCoolingSystem).Build();

        // Assert
        Assert.Equal(ComputerStatus.Good, _defoultComputer.ResultStatus.ComputerStatus);
    }

    [Theory]
    [InlineData(2, 1)]
    [InlineData(7, 6)]
    [InlineData(30, 20)]
    [InlineData(40, 35)]
    public void ChangePowerConsumptionTestNoValid(int cpuTdp, int cpuCoolingTdp)
    {
        // Arrang
        cpu = cpu.Direct(_cpuBuilder).WithTdp(cpuTdp).Build();
        cpuCoolingSystem = cpuCoolingSystem.Direct(_cpuCoolingSystemBuilder).WithTdp(cpuCoolingTdp).Build();

        // Act
        _defoultComputer = _defoultComputer.Debuilder(_ordinaryBuilder).WithCpu(cpu).WithCpuCoolingSystem(cpuCoolingSystem).Build();

        // Assert
        Assert.Equal(ComputerStatus.Disclaimer, _defoultComputer.ResultStatus.ComputerStatus);
    }
}