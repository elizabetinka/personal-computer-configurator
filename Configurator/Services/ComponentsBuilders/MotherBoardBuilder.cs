using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class MotherBoardBuilder
{
    private Chipset? _chipset;
    private int? _ddrStandart;
    private MotherBoardFormFactors? _formFactor;
    private bool _wiFiModul;
    private int? _countRamSticks;
    private Bios? _bios;
    private string? _name;
    private Socket? _socket;
    private IDictionary<int, int>? _pciELinesCounts;
    private int? _sataPortsCounts;

    public MotherBoardBuilder WithPciELinesCounts(IDictionary<int, int> pciELinesCounts)
    {
        pciELinesCounts = pciELinesCounts ?? throw new ArgumentNullException(nameof(pciELinesCounts));
        _pciELinesCounts = pciELinesCounts;
        return this;
    }

    public MotherBoardBuilder WithBios(Bios bios)
    {
        bios = bios ?? throw new ArgumentNullException(nameof(bios));
        _bios = bios;
        return this;
    }

    public MotherBoardBuilder WithWiFiModul(bool wiFiModul)
    {
        _wiFiModul = wiFiModul;
        return this;
    }

    public MotherBoardBuilder WithFormFactor(MotherBoardFormFactors formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public MotherBoardBuilder WithChipset(Chipset chipset)
    {
        chipset = chipset ?? throw new ArgumentNullException(nameof(chipset));
        _chipset = chipset;
        return this;
    }

    public MotherBoardBuilder WithSataPortsCounts(int sataPortsCounts)
    {
        sataPortsCounts = sataPortsCounts > 0 ? sataPortsCounts : throw new ArgumentException("Не валидные аргументы");
        _sataPortsCounts = sataPortsCounts;
        return this;
    }

    public MotherBoardBuilder WithCountRamSticks(int countRamSticks)
    {
        countRamSticks = countRamSticks > 0 ? countRamSticks : throw new ArgumentException("Не валидные аргументы");
        _countRamSticks = countRamSticks;
        return this;
    }

    public MotherBoardBuilder WithDdrStandart(int ddrStandart)
    {
        ddrStandart = ddrStandart > 0 ? ddrStandart : throw new ArgumentException("Не валидные аргументы");
        _ddrStandart = ddrStandart;
        return this;
    }

    public MotherBoardBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public MotherBoardBuilder WithSocket(Socket socket)
    {
        _socket = socket;
        return this;
    }

    public MotherBoard Build()
    {
        return new MotherBoard(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _pciELinesCounts ?? throw new ArgumentNullException(nameof(_pciELinesCounts)),
            _sataPortsCounts ?? throw new ArgumentNullException(nameof(_sataPortsCounts)),
            _socket ?? throw new ArgumentNullException(nameof(_socket)),
            _chipset ?? throw new ArgumentNullException(nameof(_chipset)),
            _ddrStandart ?? throw new ArgumentNullException(nameof(_ddrStandart)),
            _countRamSticks ?? throw new ArgumentNullException(nameof(_countRamSticks)),
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _bios ?? throw new ArgumentNullException(nameof(_bios)),
            _wiFiModul);
    }
}