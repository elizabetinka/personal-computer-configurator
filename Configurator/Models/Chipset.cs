using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Chipset
{
    public Chipset(string name, bool xmpProfileSupport, ICollection<int> memoryFrequencie)
    {
        Name = name;
        XmpProfileSupport = xmpProfileSupport;
        MemoryFrequencie = memoryFrequencie;
    }

    public bool XmpProfileSupport { get; init; }
    public string Name { get; init; }
    public ICollection<int> MemoryFrequencie { get; init; }

    public int GetMinUsefulFrequencie()
    {
        return MemoryFrequencie.Min();
    }
}