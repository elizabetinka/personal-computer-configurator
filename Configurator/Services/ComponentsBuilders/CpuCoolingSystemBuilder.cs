using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class CpuCoolingSystemBuilder
{
    private ICollection<Socket>? _socketSupportList;
    private Dimensions? _dimensions;
    private string? _name;
    private int? _tdp;

    public CpuCoolingSystemBuilder WithTdp(int tdp)
    {
        tdp = tdp > 0 ? tdp : throw new ArgumentException("Не валидные аргументы");
        _tdp = tdp;
        return this;
    }

    public CpuCoolingSystemBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public CpuCoolingSystemBuilder WithDimensions(Dimensions dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public CpuCoolingSystemBuilder WithSocketSupportList(ICollection<Socket> socketSupportList)
    {
        _socketSupportList = socketSupportList;
        return this;
    }

    public CpuCoolingSystem Build()
    {
        return new CpuCoolingSystem(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _dimensions ?? throw new ArgumentNullException(nameof(_dimensions)),
            _tdp ?? throw new ArgumentNullException(nameof(_tdp)),
            _socketSupportList ?? throw new ArgumentNullException(nameof(_socketSupportList)));
    }
}