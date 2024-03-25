using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public enum RamFormFactors
{
    DIMM,
    SODIMM,
    FBDIMM,
    LRDIMM,
    MiniDIMM,
}

public class Ram : IEnergyConsuming, INameble, ICloneable<Ram>
{
    private RamFormFactors _formFactor;
    private int _storageSize;
    private ICollection<JedecProfile> _jedecSupportList;
    private ICollection<XmpProfile> _xmpSupportList;

    public Ram(RamFormFactors formFactor, int storageSize, ICollection<JedecProfile> jedecSupportList, ICollection<XmpProfile> xmpSupportList, int ddrStandart, double powerConsumption, string name)
    {
        _formFactor = formFactor;
        _storageSize = storageSize;
        _jedecSupportList = jedecSupportList;
        _xmpSupportList = xmpSupportList;
        Ddr = ddrStandart;
        PowerConsumption = powerConsumption;
        Name = name;
    }

    public double PowerConsumption { get; init; }
    public string Name { get; init; }

    public int Ddr { get; init; }

    public bool IsSupportedXMP()
    {
        return _xmpSupportList.Count > 0;
    }

    public int GetMaxUsefulFrequencie()
    {
        return _jedecSupportList.Max(a => a.Frequency);
    }

    public int GetMinUsefulXMPFrequencie()
    {
        return _xmpSupportList.Max(a => a.Frequency);
    }

    public Ram Clone()
    {
        return new Ram(_formFactor, _storageSize, _jedecSupportList, _xmpSupportList, Ddr, PowerConsumption, Name);
    }

    public RamBuilder Direct(RamBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        return builder
            .WithName(Name)
            .WithPowerConsumption(PowerConsumption)
            .WithDdrStandart(Ddr)
            .WithFormFactor(_formFactor)
            .WithStorageSize(_storageSize)
            .WithJedecSupportList(_jedecSupportList)
            .WithXmpSupportList(_xmpSupportList);
    }
}