using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ComputerCase : INameble, ICloneable<ComputerCase>
{
   private Dimensions _maxGpuDimensions;
   private ICollection<MotherBoardFormFactors> _motherBoardFormFactorsSupportList;
   private Dimensions _mineDimensions;

   public ComputerCase(string name, Dimensions maxGpuDimensions, ICollection<MotherBoardFormFactors> motherBoardFormFactorsSupportList, Dimensions mineDimensions, int maxCpuCoolingHeight)
   {
      Name = name;
      _maxGpuDimensions = maxGpuDimensions;
      _motherBoardFormFactorsSupportList = motherBoardFormFactorsSupportList;
      _mineDimensions = mineDimensions;
      MaxCpuCoolingHeight = maxCpuCoolingHeight;
   }

   public string Name { get; init; }

   public int MaxCpuCoolingHeight { get; init; }

   public bool IsSupportMotherFormFactor(MotherBoardFormFactors formFactor)
   {
      return _motherBoardFormFactorsSupportList.Any(p => p == formFactor);
   }

   public ComputerCase Clone()
   {
      return new ComputerCase(Name, _maxGpuDimensions, _motherBoardFormFactorsSupportList, _mineDimensions, MaxCpuCoolingHeight);
   }

   public ComputerCaseBuilder Direct(ComputerCaseBuilder builder)
   {
      builder = builder ?? throw new ArgumentNullException(nameof(builder));
      return builder
         .WithName(Name)
         .WithMineDimensions(_mineDimensions)
         .WithMaxGpuDimensions(_maxGpuDimensions)
         .WithMaxCpuCoolingHeigh(MaxCpuCoolingHeight)
         .WithMotherBoardFormFactorsSupportList(_motherBoardFormFactorsSupportList);
   }
}