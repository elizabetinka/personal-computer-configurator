using System;
using Socket = Itmo.ObjectOrientedProgramming.Lab2.Models.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Cpu : ICloneable<Cpu>, IEnergyConsuming, INameble
{
     private double _coreFrequency;
     private int _coreCounts;

     public Cpu(string name, double coreFrequency, int coreCounts, bool gpu, int tdp, double powerConsumption, int memoryFrequencie, Socket socket)
     {
          Name = name;
          _coreFrequency = coreFrequency;
          _coreCounts = coreCounts;
          Gpu = gpu;
          PowerConsumption = powerConsumption;
          Tdp = tdp;
          MemoryFrequencie = memoryFrequencie;
          Socket = socket;
     }

     public string Name { get; init; }

     public Socket Socket { get; init; }

     public bool Gpu { get; init; }

     public double PowerConsumption { get; init; }

     public int MemoryFrequencie { get; init; }

     public int Tdp { get; init; }
     public Cpu Clone()
     {
          return new Cpu(Name, _coreFrequency, _coreCounts, Gpu, Tdp, PowerConsumption, MemoryFrequencie, Socket);
     }

     public CpuBuilder Direct(CpuBuilder builder)
     {
          builder = builder ?? throw new ArgumentNullException(nameof(builder));
          return builder
               .WithPowerConsumption(PowerConsumption)
               .WithMemoryFrequencie(MemoryFrequencie)
               .WithCoreFrequency(_coreFrequency)
               .WithTdp(Tdp)
               .WithCoreCount(_coreCounts)
               .WithSocket(Socket)
               .WithName(Name)
               .WithPowerConsumption(PowerConsumption);
     }
}