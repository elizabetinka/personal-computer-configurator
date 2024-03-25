using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ComputerCaseBuilder
{
    private Dimensions? _maxGpuDimensions;
    private ICollection<MotherBoardFormFactors>? _motherBoardFormFactorsSupportList;
    private Dimensions? _mineDimensions;
    private string? _name;
    private int? _maxCpuCoolingHeight;

    public ComputerCaseBuilder WithMotherBoardFormFactorsSupportList(ICollection<MotherBoardFormFactors> motherBoardFormFactorsSupportList)
    {
        motherBoardFormFactorsSupportList = motherBoardFormFactorsSupportList ?? throw new ArgumentNullException(nameof(motherBoardFormFactorsSupportList));
        _motherBoardFormFactorsSupportList = motherBoardFormFactorsSupportList;
        return this;
    }

    public ComputerCaseBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ComputerCaseBuilder WithMaxGpuDimensions(Dimensions maxGpuDimensions)
    {
        maxGpuDimensions = maxGpuDimensions ?? throw new ArgumentNullException(nameof(maxGpuDimensions));
        _maxGpuDimensions = maxGpuDimensions;
        return this;
    }

    public ComputerCaseBuilder WithMineDimensions(Dimensions dimensions)
    {
        dimensions = dimensions ?? throw new ArgumentNullException(nameof(dimensions));
        _mineDimensions = dimensions;
        return this;
    }

    public ComputerCaseBuilder WithMaxCpuCoolingHeigh(int maxCpuCoolingHeigh)
    {
        maxCpuCoolingHeigh = maxCpuCoolingHeigh > 0 ? maxCpuCoolingHeigh : throw new ArgumentException("Не валидные аргументы");
        _maxCpuCoolingHeight = maxCpuCoolingHeigh;
        return this;
    }

    public INameble Build()
    {
        return new ComputerCase(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _maxGpuDimensions ?? throw new ArgumentNullException(nameof(_maxGpuDimensions)),
            _motherBoardFormFactorsSupportList ?? throw new ArgumentNullException(nameof(_motherBoardFormFactorsSupportList)),
            _mineDimensions ?? throw new ArgumentNullException(nameof(_mineDimensions)),
            _maxCpuCoolingHeight ?? throw new ArgumentNullException(nameof(_maxCpuCoolingHeight)));
    }
}