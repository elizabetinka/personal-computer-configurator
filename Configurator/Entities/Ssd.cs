using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public enum ConnectionOption
{
    Sata,
    PciE,
}

public class Ssd : IEnergyConsuming, INameble, IAdditionalMemory, ICloneable<Ssd>
{
    private int _maxSpeed;

    public Ssd(string name, int storageSize, int maxSpeed, ConnectionOption connection, double powerConsumption)
    {
        Name = name;
        StorageSize = storageSize;
        _maxSpeed = maxSpeed;
        Connection = connection;
        PowerConsumption = powerConsumption;
    }

    public ConnectionOption Connection { get; init; }
    public double PowerConsumption { get; init; }
    public string Name { get; init; }

    public int StorageSize { get; init; }
    public Ssd Clone()
    {
        return new Ssd(Name, StorageSize, _maxSpeed, Connection, PowerConsumption);
    }

    public SsdBuilder Direct(SsdBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        return builder
            .WithName(Name)
            .WithPowerConsumption(PowerConsumption)
            .WithConnection(Connection)
            .WithMaxSpeed(_maxSpeed)
            .WithStorageSize(StorageSize);
    }
}