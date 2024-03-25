using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class RamBuilder
{
    private RamFormFactors? _formFactor;
    private int? _storageSize;
    private ICollection<JedecProfile>? _jedecSupportList;
    private ICollection<XmpProfile>? _xmpSupportList;
    private int? _ddrStandart;
    private double? _powerConsumption;
    private string? _name;

    public RamBuilder WithJedecSupportList(ICollection<JedecProfile> jedecSupportList)
    {
        jedecSupportList = jedecSupportList ?? throw new ArgumentNullException(nameof(jedecSupportList));
        jedecSupportList = jedecSupportList.Count != 0 ? jedecSupportList : throw new ArgumentException("Не валидные аргументы");
        _jedecSupportList = jedecSupportList;
        return this;
    }

    public RamBuilder WithXmpSupportList(ICollection<XmpProfile> xmpSupportList)
    {
        xmpSupportList = xmpSupportList ?? throw new ArgumentNullException(nameof(xmpSupportList));
        _xmpSupportList = xmpSupportList;
        return this;
    }

    public RamBuilder WithPowerConsumption(double powerConsumption)
    {
        powerConsumption = powerConsumption > 0 ? powerConsumption : throw new ArgumentException("Не валидные аргументы");
        _powerConsumption = powerConsumption;
        return this;
    }

    public RamBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public RamBuilder WithFormFactor(RamFormFactors formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public RamBuilder WithDdrStandart(int ddrStandart)
    {
        ddrStandart = ddrStandart > 0 ? ddrStandart : throw new ArgumentException("Не валидные аргументы");
        _ddrStandart = ddrStandart;
        return this;
    }

    public RamBuilder WithStorageSize(int storageSize)
    {
        storageSize = storageSize > 0 ? storageSize : throw new ArgumentException("Не валидные аргументы");
        _storageSize = storageSize;
        return this;
    }

    public Ram Build()
    {
        return new Ram(
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _storageSize ?? throw new ArgumentNullException(nameof(_storageSize)),
            _jedecSupportList ?? throw new ArgumentNullException(nameof(_jedecSupportList)),
            _xmpSupportList ?? throw new ArgumentNullException(nameof(_xmpSupportList)),
            _ddrStandart ?? throw new ArgumentNullException(nameof(_ddrStandart)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)),
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}