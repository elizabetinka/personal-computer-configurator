using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class CpuBuilder
{
    private double? _coreFrequency;
    private int? _coreCounts;
    private string? _name;
    private Socket? _socket;
    private bool _gpu;
    private double? _powerConsumption;
    private int? _memoryFrequencie;
    private int? _tdp;

    public CpuBuilder WithMemoryFrequencie(int memoryFrequencie)
    {
        memoryFrequencie = memoryFrequencie > 0 ? memoryFrequencie : throw new ArgumentException("Не валидные аргументы");
        _memoryFrequencie = memoryFrequencie;
        return this;
    }

    public CpuBuilder WithTdp(int tdp)
    {
        tdp = tdp > 0 ? tdp : throw new ArgumentException("Не валидные аргументы");
        _tdp = tdp;
        return this;
    }

    public CpuBuilder WithPowerConsumption(double powerConsumption)
    {
        powerConsumption = powerConsumption > 0 ? powerConsumption : throw new ArgumentException("Не валидные аргументы");
        _powerConsumption = powerConsumption;
        return this;
    }

    public CpuBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public CpuBuilder WithSocket(Socket socket)
    {
        _socket = socket;
        return this;
    }

    public CpuBuilder WithCoreFrequency(double coreFrequency)
    {
        coreFrequency = coreFrequency > 0 ? coreFrequency : throw new ArgumentException("Не валидные аргументы");
        _coreFrequency = coreFrequency;
        return this;
    }

    public CpuBuilder WithCoreCount(int coreCount)
    {
        coreCount = coreCount > 0 ? coreCount : throw new ArgumentException("Не валидные аргументы");
        _coreCounts = coreCount;
        return this;
    }

    public CpuBuilder WithGpu(bool gpu)
    {
        _gpu = gpu;
        return this;
    }

    public Cpu Build()
    {
        return new Cpu(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _coreFrequency ?? throw new ArgumentNullException(nameof(_coreFrequency)),
            _coreCounts ?? throw new ArgumentNullException(nameof(_coreCounts)),
            _gpu,
            _tdp ?? throw new ArgumentNullException(nameof(_coreCounts)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)),
            _memoryFrequencie ?? throw new ArgumentNullException(nameof(_memoryFrequencie)),
            _socket ?? throw new ArgumentNullException(nameof(_socket)));
    }
}