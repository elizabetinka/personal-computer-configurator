using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class GpuBuilder
{
    private int? _storageSize;
    private double? _pciEVersion;
    private int? _frequency;
    private double? _powerConsumption;
    private string? _name;
    private Dimensions? _dimensions;

    public GpuBuilder WithDimensions(Dimensions dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public GpuBuilder WithPciEVersion(double pciEVersion)
    {
        pciEVersion = pciEVersion > 0 ? pciEVersion : throw new ArgumentException("Не валидные аргументы");
        _pciEVersion = pciEVersion;
        return this;
    }

    public GpuBuilder WithFrequency(int frequency)
    {
        frequency = frequency > 0 ? frequency : throw new ArgumentException("Не валидные аргументы");
        _frequency = frequency;
        return this;
    }

    public GpuBuilder WithPowerConsumption(double powerConsumption)
    {
        powerConsumption = powerConsumption > 0 ? powerConsumption : throw new ArgumentException("Не валидные аргументы");
        _powerConsumption = powerConsumption;
        return this;
    }

    public GpuBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public GpuBuilder WithStorageSize(int storageSize)
    {
        storageSize = storageSize > 0 ? storageSize : throw new ArgumentException("Не валидные аргументы");
        _storageSize = storageSize;
        return this;
    }

    public Gpu Build()
    {
        return new Gpu(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _storageSize ?? throw new ArgumentNullException(nameof(_storageSize)),
            _pciEVersion ?? throw new ArgumentNullException(nameof(_pciEVersion)),
            _frequency ?? throw new ArgumentNullException(nameof(_frequency)),
            _dimensions ?? throw new ArgumentNullException(nameof(_dimensions)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}