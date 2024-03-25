using System.Collections;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class CompatibleComponentsTestData : IEnumerable<object?[]>
{
    private readonly List<object?[]> _data = new List<object?[]>
    {
        new object?[] { "GIGABYTE B550 AORUS ELITE V2", "AMD Ryzen 5 5500", "LIAN LI Galahad AIO 360", "Kingston FURY Beast", "Cougar Duoface Pro RGB", "Cougar STX 700W", null, "Seagate BarraCuda", "Palit GeForce GTX 1660 SUPER GamingPro", "TP-LINK Archer T5E" },
        new object?[] { "GIGABYTE B550 AORUS ELITE V2", "AMD Ryzen 5 4600G", "LIAN LI Galahad AIO 360", "Kingston FURY Beast", "Cougar Duoface Pro RGB", "Cougar STX 700W", null, "Seagate BarraCuda", null, null },
        new object?[] { "GIGABYTE B760M DS3H DDR4", "Intel Core i3-12100", "AeroCool Verkho Plus", "Kingston FURY Beast", "Cougar Duoface Pro RGB", "Cougar STX 700W", null, "WD Purple Surveillance", "MSI AMD Radeon RX 550 AERO ITX OC", null },
    };

    public IEnumerator<object?[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}