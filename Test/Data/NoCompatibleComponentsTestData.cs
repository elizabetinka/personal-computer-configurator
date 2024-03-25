using System.Collections;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class NoCompatibleComponentsTestData : IEnumerable<object?[]>
{
    private readonly List<object?[]> _data = new List<object?[]>
    {
        new object?[] { "GIGABYTE B550 AORUS ELITE V2", "AMD Ryzen 5 5500", "LIAN LI Galahad AIO 360", "Kingston FURY Beast", "Cougar Duoface Pro RGB", "Cougar STX 700W", null, "Seagate BarraCuda", null, "TP-LINK Archer T5E" },
        new object?[] { "GIGABYTE Z790 AORUS ELITE AX", "AMD Ryzen 5 5500", "LIAN LI Galahad AIO 360", "Kingston FURY Beast", "Cougar Duoface Pro RGB", "Cougar STX 700W", null, "Seagate BarraCuda", null, "TP-LINK Archer T5E" },
        new object?[] { "GIGABYTE Z790 AORUS ELITE AX", "AMD Ryzen 5 5500", "LIAN LI Galahad AIO 360", "G.Skill AEGIS", "Cougar Duoface Pro RGB", "Cougar STX 700W", null, "Seagate BarraCuda", null, "TP-LINK Archer T5E" },
        new object?[] { "MSI PRO H610M-E DDR4", "AMD Ryzen 5 4600G", "LIAN LI Galahad AIO 360", "Kingston FURY Beast", "Cougar Duoface Pro RGB", "Cougar STX 700W", null, "Seagate BarraCuda", null, null },
    };

    public IEnumerator<object?[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}