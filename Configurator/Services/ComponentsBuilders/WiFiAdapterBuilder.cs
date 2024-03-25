using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class WiFiAdapterBuilder
{
    private int? _wiFiStandart;
    private double? _pciEVersion;
    private bool _bluetoothModul;
    private double? _powerConsumption;
    private string? _name;

    public WiFiAdapterBuilder WithBluetoothModul(bool bluetoothModul)
    {
        _bluetoothModul = bluetoothModul;
        return this;
    }

    public WiFiAdapterBuilder WithPciEVersion(double pciEVersion)
    {
        pciEVersion = pciEVersion > 0 ? pciEVersion : throw new ArgumentException("Не валидные аргументы");
        _pciEVersion = pciEVersion;
        return this;
    }

    public WiFiAdapterBuilder WithWiFiStandart(int wiFiStandart)
    {
        wiFiStandart = wiFiStandart > 0 ? wiFiStandart : throw new ArgumentException("Не валидные аргументы");
        _wiFiStandart = wiFiStandart;
        return this;
    }

    public WiFiAdapterBuilder WithPowerConsumption(double powerConsumption)
    {
        powerConsumption = powerConsumption > 0 ? powerConsumption : throw new ArgumentException("Не валидные аргументы");
        _powerConsumption = powerConsumption;
        return this;
    }

    public WiFiAdapterBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public WiFiAdapter Build()
    {
        return new WiFiAdapter(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _wiFiStandart ?? throw new ArgumentNullException(nameof(_wiFiStandart)),
            _pciEVersion ?? throw new ArgumentNullException(nameof(_pciEVersion)),
            _bluetoothModul,
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}