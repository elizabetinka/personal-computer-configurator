using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class PowerSupply : INameble, ICloneable<PowerSupply>
{
    public PowerSupply(string name, double peakLoad)
    {
        Name = name;
        PeakLoad = peakLoad;
    }

    public double PeakLoad { get; init; }
    public string Name { get; init; }
    public PowerSupply Clone()
    {
        return new PowerSupply(Name, PeakLoad);
    }

    public PowerSupplyBuilder Direct(PowerSupplyBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        return builder
            .WithName(Name)
            .WithPeakLoad(PeakLoad);
    }
}