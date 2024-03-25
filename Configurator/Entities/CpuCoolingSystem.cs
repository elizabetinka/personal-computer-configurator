using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class CpuCoolingSystem : ISizeble, INameble, ICloneable<CpuCoolingSystem>
{
    private ICollection<Socket> _socketSupportList;

    public CpuCoolingSystem(string name, Dimensions dimensions, int tdp, ICollection<Socket> socketSupportList)
    {
        Name = name;
        Dimensions = dimensions;
        Tdp = tdp;
        _socketSupportList = socketSupportList;
    }

    public Dimensions Dimensions { get; init; }
    public string Name { get; init; }
    public int Tdp { get; init; }

    public void WithSocketSupportCollection(ICollection<Socket> socketSupportList)
    {
        _socketSupportList = socketSupportList;
    }

    public bool IsSocketSupport(Socket socket)
    {
        return _socketSupportList.Any(a => a.Name == socket.Name);
    }

    public CpuCoolingSystem Clone()
    {
        return new CpuCoolingSystem(Name, Dimensions, Tdp, _socketSupportList);
    }

    public CpuCoolingSystemBuilder Direct(CpuCoolingSystemBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        return builder
            .WithName(Name)
            .WithTdp(Tdp)
            .WithDimensions(Dimensions)
            .WithSocketSupportList(_socketSupportList);
    }
}