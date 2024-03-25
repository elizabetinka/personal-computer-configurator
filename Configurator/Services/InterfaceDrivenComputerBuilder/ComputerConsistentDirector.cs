using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

// Мной было принято решение оставить два билдера для компьютера. Так как обычный- позволяет дебилдером переделывать сборку на лету. А этот билдер позволяет красиво и последовательно(последовательно для полльзователя) собрать компьютер.

// Тут пришлось дублировать много чего, по причине того, что благодаря этом билдеру можно прям
// последовательно строить объект,
// но если подумать, логично, что он не подойдет для Rebuild (метод Direct в классе Computer),
// так как этот метод создан для  замены ОДНОЙ компоненты компьютера, а если испоьзовать InterfaceDrivenBuilder придется менять все компоненты, еще и с учетом порядка
// (поэтому был созданы новый интерфейсы, чтобы на этапе комиляции этот билдеры туда не подходили)
public class ComputerConsistentDirector
{
    public IMotherBoardBuilder Builder { get; } = new ComputerConsistentBuilder();

    public IComputerConsistentBuilder Direct(string motherBoardName, string cpuName, string cpuCoolingSystemName, string ramName, string computerCaseName, string powerSupplyName, string? ssdName, string? hddName, string? gpuName, string? wiFiAdapterName, ComputerComponentsFactory componentsFactory)
    {
        componentsFactory = componentsFactory ?? throw new ArgumentNullException(nameof(componentsFactory));
        MotherBoard motherBoard = componentsFactory.CreateMotherBoardByName(motherBoardName) ?? throw new ArgumentException(nameof(MotherBoard));
        Cpu cpu = componentsFactory.CreateCpuByName(cpuName) ?? throw new ArgumentException(nameof(cpu));
        CpuCoolingSystem cpuCoolingSystem = componentsFactory.CreateCpuCoolingSystemByName(cpuCoolingSystemName) ?? throw new ArgumentException(nameof(CpuCoolingSystem));
        ComputerCase computerCase = componentsFactory.CreateComputerCaseByName(computerCaseName) ?? throw new ArgumentException(nameof(ComputerCase));
        Ram ram = componentsFactory.CreateRamByName(ramName) ?? throw new ArgumentException(nameof(Ram));
        PowerSupply powerSupply = componentsFactory.CreatePowerSupplyByName(powerSupplyName) ?? throw new ArgumentException(nameof(PowerSupply));
        Gpu? gpu = null;
        IAdditionalMemory? memory = null;
        WiFiAdapter? wiFiAdapter = null;

        if (hddName is null == ssdName is null)
        {
            throw new ArgumentException(nameof(IAdditionalMemory));
        }

        if (gpuName is not null)
        {
            gpu = componentsFactory.CreateGpuByName(gpuName) ?? throw new ArgumentException(nameof(Gpu));
        }

        if (hddName is not null)
        {
            memory = componentsFactory.CreateHddByName(hddName) ?? throw new ArgumentException(nameof(Hdd));
        }

        if (ssdName is not null)
        {
            memory = componentsFactory.CreateSsdByName(ssdName) ?? throw new ArgumentException(nameof(Ssd));
        }

        if (wiFiAdapterName is not null)
        {
            wiFiAdapter = componentsFactory.CreateWiFiAdapterByName(wiFiAdapterName) ?? throw new ArgumentException(nameof(WiFiAdapter));
        }

        memory = memory ?? throw new ArgumentException(nameof(memory));

        return Builder
            .WithMotherBoard(motherBoard)
            .WithCpu(cpu)
            .WithCpuCoolingSystem(cpuCoolingSystem)
            .WithRam(ram)
            .WithComputerCase(computerCase)
            .WithAdditionalMemory(memory)
            .YouCanAddGpu(gpu)
            .WithPowerSupply(powerSupply)
            .YouCanAddWiFiAdapter(wiFiAdapter);
    }
}