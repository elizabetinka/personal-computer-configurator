using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class HddBuilder
{
    private ConnectionOption? _connection;
    private int? _spindleSpeed;
    private int? _storageSize;
    private double? _powerConsumption;
    private string? _name;

    public HddBuilder WithConnection(ConnectionOption connection)
    {
        _connection = connection;
        return this;
    }

    public HddBuilder WithSpindleSpeed(int spindleSpeed)
    {
        spindleSpeed = spindleSpeed > 0 ? spindleSpeed : throw new ArgumentException("Не валидные аргументы");
        _spindleSpeed = spindleSpeed;
        return this;
    }

    public HddBuilder WithPowerConsumption(double powerConsumption)
    {
        powerConsumption = powerConsumption > 0 ? powerConsumption : throw new ArgumentException("Не валидные аргументы");
        _powerConsumption = powerConsumption;
        return this;
    }

    public HddBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public HddBuilder WithStorageSize(int storageSize)
    {
        storageSize = storageSize > 0 ? storageSize : throw new ArgumentException("Не валидные аргументы");
        _storageSize = storageSize;
        return this;
    }

    public Hdd Build()
    {
        return new Hdd(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _storageSize ?? throw new ArgumentNullException(nameof(_storageSize)),
            _spindleSpeed ?? throw new ArgumentNullException(nameof(_spindleSpeed)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}