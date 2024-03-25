using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class WiFiAdapter : IEnergyConsuming, INameble, ICloneable<WiFiAdapter>
{
    private int _wiFiStandart;
    private double _pciEVersion;
    private bool _bluetoothModul;

    public WiFiAdapter(string name, int wiFiStandart, double pciEVersion, bool bluetoothModul, double powerConsumption)
    {
        Name = name;
        _wiFiStandart = wiFiStandart;
        _pciEVersion = pciEVersion;
        _bluetoothModul = bluetoothModul;
        PowerConsumption = powerConsumption;
    }

    public double PowerConsumption { get; init; }
    public string Name { get; init; }
    public WiFiAdapter Clone()
    {
        return new WiFiAdapter(Name, _wiFiStandart, _pciEVersion, _bluetoothModul, PowerConsumption);
    }

    public WiFiAdapterBuilder Direct(WiFiAdapterBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        return builder
            .WithName(Name)
            .WithPowerConsumption(PowerConsumption)
            .WithBluetoothModul(_bluetoothModul)
            .WithWiFiStandart(_wiFiStandart)
            .WithPciEVersion(_pciEVersion);
    }
}