using System;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Computer : IComputerDebuilderDirector
{
    private Cpu _cpu;
    private MotherBoard _motherBoard;
    private CpuCoolingSystem _cpuCoolingSystem;
    private Ram _ram;
    private ComputerCase _computerCase;
    private IAdditionalMemory _additionalMemory;
    private PowerSupply _powerSupply;
    private Gpu? _gpu;
    private WiFiAdapter? _wiFiAdapter;

    public Computer(Cpu cpu, MotherBoard motherBoard, CpuCoolingSystem cpuCoolingSystem, Ram ram, ComputerCase computerCase, IAdditionalMemory additionalMemory, PowerSupply powerSupply, Gpu? gpu, WiFiAdapter? wiFiAdapter, ComputerResultStatus resultStatus)
    {
        _cpu = cpu;
        _motherBoard = motherBoard;
        _cpuCoolingSystem = cpuCoolingSystem;
        _ram = ram;
        _computerCase = computerCase;
        _additionalMemory = additionalMemory;
        _powerSupply = powerSupply;
        _gpu = gpu;
        _wiFiAdapter = wiFiAdapter;
        ResultStatus = resultStatus;
    }

    public ComputerResultStatus ResultStatus { get; }

    public IOrdinaryComputerBuilder Debuilder(IOrdinaryComputerBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        return builder
            .WithMotherBoard(_motherBoard)
            .WithCpu(_cpu).WithCpuCoolingSystem(_cpuCoolingSystem)
            .WithRam(_ram)
            .WithComputerCase(_computerCase)
            .WithAdditionalMemory(_additionalMemory)
            .WithGpu(_gpu)
            .WithPowerSupply(_powerSupply)
            .WithWiFiAdapter(_wiFiAdapter);
    }
}