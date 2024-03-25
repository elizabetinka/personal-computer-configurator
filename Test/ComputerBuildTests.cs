using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ComputerBuildTests
{
    private DataBase _dataBase;
    private ComputerComponentsFactory _componentsFactory;
    private ComputerConsistentDirector _consistentDirector;

    public ComputerBuildTests()
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

        _consistentDirector = new ComputerConsistentDirector();
    }

    [Theory]
    [ClassData(typeof(CompatibleComponentsTestData))]
    public void CreateByDirectorTestValid(string motherBoardName, string cpuName, string cpuCoolingSystemName, string ramName, string computerCaseName, string powerSupplyName, string? ssdName, string? hddName, string? gpuName, string? wiFiAdapterName)
    {
        // Arrang

        // Act
        Computer computer = _consistentDirector.Direct(motherBoardName, cpuName, cpuCoolingSystemName, ramName, computerCaseName, powerSupplyName, ssdName, hddName, gpuName, wiFiAdapterName, _componentsFactory).Build();

        // Assert
        Assert.Equal(ComputerStatus.Good, computer.ResultStatus.ComputerStatus);
    }

    [Theory]
    [ClassData(typeof(NoCompatibleComponentsTestData))]
    public void CreateByDirectorTestNoValid(string motherBoardName, string cpuName, string cpuCoolingSystemName, string ramName, string computerCaseName, string powerSupplyName, string? ssdName, string? hddName, string? gpuName, string? wiFiAdapterName)
    {
        // Arrang

        // Act
        Computer computer = _consistentDirector.Direct(motherBoardName, cpuName, cpuCoolingSystemName, ramName, computerCaseName, powerSupplyName, ssdName, hddName, gpuName, wiFiAdapterName, _componentsFactory).Build();

        // Assert
        Assert.Equal(ComputerStatus.NotWork, computer.ResultStatus.ComputerStatus);
    }
}