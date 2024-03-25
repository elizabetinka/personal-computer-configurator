using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class PowerSupplyBuilder
{
    private double? _peakLoad;
    private string? _name;

    public PowerSupplyBuilder WithPeakLoad(double peakLoad)
    {
        peakLoad = peakLoad > 0 ? peakLoad : throw new ArgumentException("Не валидные аргументы");
        _peakLoad = peakLoad;
        return this;
    }

    public PowerSupplyBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public PowerSupply Build()
    {
        return new PowerSupply(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _peakLoad ?? throw new ArgumentNullException(nameof(_peakLoad)));
    }
}