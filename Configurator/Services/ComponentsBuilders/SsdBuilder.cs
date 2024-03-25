using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class SsdBuilder
{
    private ConnectionOption? _connection;
    private int? _maxSpeed;
    private int? _storageSize;
    private double? _powerConsumption;
    private string? _name;

    public SsdBuilder WithConnection(ConnectionOption connection)
    {
        _connection = connection;
        return this;
    }

    public SsdBuilder WithMaxSpeed(int maxSpeed)
    {
        maxSpeed = maxSpeed > 0 ? maxSpeed : throw new ArgumentException("Не валидные аргументы");
        _maxSpeed = maxSpeed;
        return this;
    }

    public SsdBuilder WithPowerConsumption(double powerConsumption)
    {
        powerConsumption = powerConsumption > 0 ? powerConsumption : throw new ArgumentException("Не валидные аргументы");
        _powerConsumption = powerConsumption;
        return this;
    }

    public SsdBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public SsdBuilder WithStorageSize(int storageSize)
    {
        storageSize = storageSize > 0 ? storageSize : throw new ArgumentException("Не валидные аргументы");
        _storageSize = storageSize;
        return this;
    }

    public Ssd Build()
    {
        return new Ssd(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _storageSize ?? throw new ArgumentNullException(nameof(_storageSize)),
            _maxSpeed ?? throw new ArgumentNullException(nameof(_maxSpeed)),
            _connection ?? throw new ArgumentNullException(nameof(_connection)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}