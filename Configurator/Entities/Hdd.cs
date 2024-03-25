using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Hdd : INameble, IAdditionalMemory, ICloneable<Hdd>
{
    private int _spindleSpeed;

    public Hdd(string name, int storageSize, int spindleSpeed, double powerConsumption)
    {
        Name = name;
        StorageSize = storageSize;
        _spindleSpeed = spindleSpeed;
        PowerConsumption = powerConsumption;
        Connection = ConnectionOption.Sata;
    }

    public double PowerConsumption { get; init; }
    public string Name { get; init; }

    public int StorageSize { get; init; }
    public ConnectionOption Connection { get; init; }
    public Hdd Clone()
    {
        return new Hdd(Name, StorageSize, _spindleSpeed, PowerConsumption);
    }

    public HddBuilder Direct(HddBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        return builder
            .WithName(Name)
            .WithPowerConsumption(PowerConsumption)
            .WithConnection(Connection)
            .WithSpindleSpeed(_spindleSpeed)
            .WithStorageSize(StorageSize);
    }
}