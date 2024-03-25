using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public enum MotherBoardFormFactors
{
    StandartATX,
    EATX,
    MiniATX,
    MicroATX,
    MiniITX,
    SsiCeb,
}

public class MotherBoard : ICloneable<MotherBoard>, INameble
{
    private Chipset _chipset;
    private int _countRamSticks;
    private Bios _bios;
    public MotherBoard(string name, IDictionary<int, int> pciELinesCounts, int sataPortsCounts, Socket socket, Chipset chipset, int ddrStandart, int countRamSticks, MotherBoardFormFactors formFactor, Bios bios, bool wiFiModul = false)
    {
        Name = name;
        PciELinesCounts = pciELinesCounts;
        SataPortsCounts = sataPortsCounts;
        Socket = socket;
        _chipset = chipset;
        Ddr = ddrStandart;
        _countRamSticks = countRamSticks;
        FormFactor = formFactor;
        _bios = bios;
        WiFiModul = wiFiModul;
    }

    public string Name { get; init; }
    public MotherBoardFormFactors FormFactor { get; init; }
    public int Ddr { get; init; }

    public bool WiFiModul { get; init; }
    public Socket Socket { get; init; }

    public IDictionary<int, int> PciELinesCounts { get; init; }
    public int SataPortsCounts { get; init; }
    public MotherBoard Clone()
    {
        return new MotherBoard(Name, PciELinesCounts, SataPortsCounts, Socket, _chipset, Ddr, _countRamSticks, FormFactor, _bios);
    }

    public MotherBoardBuilder Direct(MotherBoardBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        return builder
            .WithName(Name)
            .WithSocket(Socket)
            .WithBios(_bios)
            .WithChipset(_chipset)
            .WithFormFactor(FormFactor)
            .WithDdrStandart(Ddr)
            .WithCountRamSticks(_countRamSticks)
            .WithSataPortsCounts(SataPortsCounts)
            .WithWiFiModul(WiFiModul)
            .WithPciELinesCounts(PciELinesCounts);
    }

    public bool IsSupportCpu(Cpu cpu)
    {
        return _bios.IsSupportCpu(cpu);
    }

    public bool IsSupportedXMP()
    {
        return _chipset.XmpProfileSupport;
    }

    public int GetMinUsefulFrequencie()
    {
        return _chipset.GetMinUsefulFrequencie();
    }
}