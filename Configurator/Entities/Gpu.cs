using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Gpu : ISizeble, INameble, IEnergyConsuming, ICloneable<Gpu>
{
    private int _storageSize;
    private double _pciEVersion;
    private int _frequency;

    public Gpu(string name, int storageSize, double pciEVersion, int frequency, Dimensions dimensions, double powerConsumption)
    {
        _storageSize = storageSize;
        _pciEVersion = pciEVersion;
        _frequency = frequency;
        Dimensions = dimensions;
        Name = name;
        PowerConsumption = powerConsumption;
    }

    public Dimensions Dimensions { get; init; }
    public string Name { get; init; }
    public double PowerConsumption { get; init; }
    public Gpu Clone()
    {
        return new Gpu(Name, _storageSize, _pciEVersion, _frequency, Dimensions, PowerConsumption);
    }

    public GpuBuilder Direct(GpuBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        return builder
            .WithName(Name)
            .WithPowerConsumption(PowerConsumption)
            .WithDimensions(Dimensions)
            .WithFrequency(_frequency)
            .WithStorageSize(_storageSize)
            .WithPciEVersion(_pciEVersion);
    }
}