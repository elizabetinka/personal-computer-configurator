using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class DataBase
{
    public DataBase()
    {
        CpuList = new List<Cpu>
        {
            new Cpu("EPYC 9654", 2.4, 96, false, 360, 360, 4800, new Socket("SP5")),
            new Cpu("EPYC 9650", 2.4, 96, false, 360, 360, 4800, new Socket("SP4")),
            new Cpu("AMD Ryzen 5 4600G", 3.7, 6, true, 65, 65, 3200, new Socket("AM4")),
            new Cpu("AMD Ryzen 5 5500", 3.6, 6, false, 65, 65, 3200, new Socket("AM4")),
            new Cpu("AMD Ryzen 5 3600", 3.6, 6, false, 65, 65, 3200, new Socket("AM4")),
            new Cpu("Intel Core i3-12100", 3.3, 4, true, 89, 60, 4800, new Socket("LGA 1700")),
            new Cpu("Intel Core i7-12700", 2.1, 12, true, 180, 65, 4800, new Socket("LGA 1700")),
            new Cpu("Intel Core i9 12900K", 3.2, 16, true, 100, 125, 4800, new Socket("LGA 1700")),
            new Cpu("Intel Pentium Gold G7400", 3.7, 2, true, 46, 46, 4800, new Socket("LGA 1700")),
            new Cpu("Intel Core i9-13900K", 3.0, 24, true, 253, 124, 5600, new Socket("LGA 1700")),
        };

        MotherBoardsList = new List<MotherBoard>
        {
            new MotherBoard("GIGABYTE B550 AORUS ELITE V2", GetDictionaryPciELinesCounts(1, 0, 0, 0, 3), 4, new Socket("AM4"), new Chipset("AMD B550", true, new List<int> { 3200, 3400, 3600, 3733, 4000, 4600 }), 4, 4, MotherBoardFormFactors.StandartATX, new Bios(BiosType.UEFI, "D15", new List<Cpu> { GetByName("AMD Ryzen 5 4600G"), GetByName("AMD Ryzen 5 5500"), GetByName("AMD Ryzen 5 5500"), GetByName("AMD Ryzen 5 3600") })),
            new MotherBoard("MSI PRO H610M-E DDR4", GetDictionaryPciELinesCounts(1, 0, 0, 0, 1), 4, new Socket("LGA 1700"), new Chipset("Intel H610", false, new List<int> { 2133, 2400, 2666, 2800, 2933, 3000, 3200 }), 4, 2, MotherBoardFormFactors.MicroATX, new Bios(BiosType.UEFI, "A70", new List<Cpu> { GetByName("Intel Core i3-12100"), GetByName("Intel Core i7-12700"), GetByName("Intel Core i9 12900K") })),
            new MotherBoard("GIGABYTE B760M DS3H DDR4", GetDictionaryPciELinesCounts(2, 0, 0, 0, 1), 4, new Socket("LGA 1700"), new Chipset("Intel B760", true, new List<int> { 3200, 3300 }), 4, 4, MotherBoardFormFactors.MicroATX, new Bios(BiosType.UEFI, "T0d", new List<Cpu> { GetByName("Intel Core i3-12100"), GetByName("Intel Core i7-12700"), GetByName("Intel Core i9 12900K"), GetByName("Intel Core i9-13900K"), GetByName("Intel Pentium Gold G7400") })),
            new MotherBoard("GIGABYTE Z790 AORUS ELITE AX", GetDictionaryPciELinesCounts(0, 0, 0, 0, 3), 6, new Socket("LGA 1700"), new Chipset("Intel Z790", true, new List<int> { 4800, 5200, 5400, 5600, 5800, 6000, 6600, 7000, 7400, 7600 }), 5, 4, MotherBoardFormFactors.StandartATX, new Bios(BiosType.UEFI, "T0d", new List<Cpu> { GetByName("Intel Core i3-12100"), GetByName("Intel Core i7-12700"), GetByName("Intel Core i9 12900K"), GetByName("Intel Core i9-13900K"), GetByName("Intel Pentium Gold G7400") })),
        };

        CpuCoolingSystemList = new List<CpuCoolingSystem>
        {
            new CpuCoolingSystem("AeroCool Verkho Plus", new Dimensions(128, 128, 68), 110, new List<Socket> { new("LGA 1700"), new("LGA 1200"), new("LGA 1155"), new("FM2+"), new("FM2"), new("AM5"), new("AM4"), new("AM3+") }),
            new CpuCoolingSystem("DEEPCOOL AK620", new Dimensions(138, 129, 160), 260, new List<Socket> { new("LGA 1700"), new("LGA 1200"), new("LGA 1155"), new("FM2+"), new("FM2"), new("AM5"), new("AM4"), new("AM3+"), new("LGA 2011"), new("LGA 2066") }),
            new CpuCoolingSystem("DEEPCOOL GAMMAXX 300", new Dimensions(76, 121, 136), 130, new List<Socket> { new("LGA 1700"), new("LGA 1200"), new("LGA 1155"), new("AM5"), new("AM4") }),
            new CpuCoolingSystem("LIAN LI Galahad AIO 360", new Dimensions(360, 120, 62), 300, new List<Socket> { new("LGA 1700"), new("LGA 1200"), new("LGA 1155"), new("AM5"), new("AM4"), new("LGA 2011"), new("LGA 2066") }),
            new CpuCoolingSystem("DEEPCOOL Alta 9", new Dimensions(59, 113, 113), 65, new List<Socket> { new("LGA 1700") }),
        };

        RamList = new List<Ram>
        {
            new Ram(RamFormFactors.DIMM, 16, new List<JedecProfile> { new(3400, 1.2) }, new List<XmpProfile> { new(3000, 1.35, new Timing(15, 17, 17)), new(3200, 1.35, new Timing(16, 18, 18)) }, 4, 1.35, "Kingston FURY Beast"),
            new Ram(RamFormFactors.DIMM, 16, new List<JedecProfile> { new(2666, 1.5) }, new List<XmpProfile> { new(3200, 1.35, new Timing(16, 18, 18, 38)) }, 4, 1.35, "G.Skill AEGIS"),
            new Ram(RamFormFactors.DIMM, 32, new List<JedecProfile> { new(5600, 1.35) }, new List<XmpProfile> { new(5600, 1.25, new Timing(36, 36, 36)) }, 5, 1.25, "ADATA XPG Lancer"),
        };

        GpuList = new List<Gpu>
        {
            new Gpu("Palit GeForce GTX 1660 SUPER GamingPro", 6, 3.0, 1530, new Dimensions(235, 115, 40), 125),
            new Gpu("KFA2 GeForce RTX 3060 CORE (LHR)", 12, 4.0, 1320, new Dimensions(245, 112, 42), 170),
            new Gpu("MSI AMD Radeon RX 550 AERO ITX OC", 4, 3.0, 1102, new Dimensions(155, 112, 38), 50),
        };

        SsdList = new List<Ssd>
        {
            new Ssd("Kingston A400", 480, 500, ConnectionOption.Sata, 1.53),
            new Ssd("Samsung 870 EVO", 1000, 560, ConnectionOption.Sata, 4),
            new Ssd("AMD Radeon R5 NVMe Series", 128, 1800, ConnectionOption.PciE, 2),
        };

        HddList = new List<Hdd>
        {
            new Hdd("Seagate BarraCuda", 2000, 7200, 3.7),
            new Hdd("WD Purple Surveillance", 4000, 5400, 4.7),
            new Hdd("WD Blue", 2000, 5400, 4.1),
        };

        ComuterCaseList = new List<ComputerCase>
        {
            new ComputerCase("Cougar Duoface Pro RGB", new Dimensions(390, int.MaxValue, int.MaxValue), new List<MotherBoardFormFactors> { MotherBoardFormFactors.EATX, MotherBoardFormFactors.StandartATX, MotherBoardFormFactors.MiniITX, MotherBoardFormFactors.MicroATX, MotherBoardFormFactors.SsiCeb }, new Dimensions(465, 240, 496), 190),
            new ComputerCase("ARDOR GAMING Rare M2 ARGB", new Dimensions(380, int.MaxValue, int.MaxValue), new List<MotherBoardFormFactors> { MotherBoardFormFactors.EATX, MotherBoardFormFactors.StandartATX, MotherBoardFormFactors.MiniITX, MotherBoardFormFactors.MicroATX }, new Dimensions(447, 220, 510), 165),
            new ComputerCase("DEXP DC-201M", new Dimensions(300, int.MaxValue, int.MaxValue), new List<MotherBoardFormFactors> { MotherBoardFormFactors.MiniITX, MotherBoardFormFactors.MicroATX }, new Dimensions(360, 175, 360), 142),
        };

        PowerSuppluList = new List<PowerSupply>
        {
            new PowerSupply("Cougar STX 700W", 700),
            new PowerSupply("DEEPCOOL PF600", 600),
            new PowerSupply("DEEPCOOL PF450", 450),
        };

        WiFiAdapterList = new List<WiFiAdapter>
        {
            new WiFiAdapter("TP-LINK Archer T5E", 5, 3.0, true, 1.7),
            new WiFiAdapter("ASUS PCE-AX3000", 6, 4.0, true, 1.5),
            new WiFiAdapter("TP-LINK Archer T2E", 5, 3.0, false, 1.8),
        };
    }

    public ICollection<Cpu> CpuList { get; private set; }
    public ICollection<Ssd> SsdList { get; private set; }

    public ICollection<WiFiAdapter> WiFiAdapterList { get; private set; }
    public ICollection<ComputerCase> ComuterCaseList { get; private set; }

    public ICollection<PowerSupply> PowerSuppluList { get; private set; }
    public ICollection<Hdd> HddList { get; private set; }
    public ICollection<Gpu> GpuList { get; private set; }
    public ICollection<Ram> RamList { get; private set; }
    public ICollection<CpuCoolingSystem> CpuCoolingSystemList { get; private set; }
    public ICollection<MotherBoard> MotherBoardsList { get; private set; }

    public void AddCpu(Cpu cpu)
    {
        CpuList.Add(cpu);
    }

    public void AddMotherBoard(MotherBoard motherBoard)
    {
        MotherBoardsList.Add(motherBoard);
    }

    private static IDictionary<int, int> GetDictionaryPciELinesCounts(int count1xPciE, int count2xPciE, int count4XPciE, int count8xPciE, int count16xPciE)
    {
        var res = new Dictionary<int, int>(5);
        res.Add(1, count1xPciE);
        res.Add(2, count2xPciE);
        res.Add(4, count4XPciE);
        res.Add(8, count8xPciE);
        res.Add(16, count16xPciE);
        return res;
    }

    private Cpu GetByName(string name)
    {
        return CpuList.FirstOrDefault(cpu => cpu.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            ?.Clone() ?? throw new ArgumentNullException(name);
    }
}