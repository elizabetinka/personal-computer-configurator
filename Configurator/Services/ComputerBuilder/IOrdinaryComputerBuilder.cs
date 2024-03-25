using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerBuilder;

public interface IOrdinaryComputerBuilder : IBuildble
{
    public IOrdinaryComputerBuilder WithCpu(Cpu cpu);

    public IOrdinaryComputerBuilder WithMotherBoard(MotherBoard motherBoard);

    public IOrdinaryComputerBuilder WithCpuCoolingSystem(CpuCoolingSystem cpuCoolingSystem);

    public IOrdinaryComputerBuilder WithRam(Ram ram);

    public IOrdinaryComputerBuilder WithAdditionalMemory(IAdditionalMemory additionalMemory);

    public IOrdinaryComputerBuilder WithGpu(Gpu? gpu);

    public IOrdinaryComputerBuilder WithComputerCase(ComputerCase computerCase);

    public IOrdinaryComputerBuilder WithPowerSupply(PowerSupply powerSupply);

    public IOrdinaryComputerBuilder WithWiFiAdapter(WiFiAdapter? wiFiAdapter);
}