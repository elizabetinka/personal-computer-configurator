using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public enum BiosType
{
    AWARD,
    AMI,
    UEFI,
}

public class Bios
{
    private BiosType _type;
    private string _version;
    private ICollection<Cpu> _cpuSupportList;

    public Bios(BiosType type, string version, ICollection<Cpu> cpuSupportList)
    {
        _type = type;
        _version = version;
        _cpuSupportList = cpuSupportList;
    }

    public void WithCpuSupportCollection(ICollection<Cpu> cpuSupportList)
    {
        _cpuSupportList = cpuSupportList;
    }

    public bool IsSupportCpu(Cpu cpu)
    {
        return _cpuSupportList.Any(p => p.Name == cpu.Name);
    }
}