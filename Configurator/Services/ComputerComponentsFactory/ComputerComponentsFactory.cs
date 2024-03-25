using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerComponentsFactory
{
    private readonly IFactory<Cpu> _cpuFactory;
    private readonly IFactory<CpuCoolingSystem> _cpuCoolingSystemFactory;
    private readonly IFactory<Ram> _ramFactory;
    private readonly IFactory<Ssd> _ssdFactory;
    private readonly IFactory<Hdd> _hddFactory;
    private readonly IFactory<Gpu> _gpuFactory;
    private readonly IFactory<PowerSupply> _powerSupplyFactory;
    private readonly IFactory<ComputerCase> _computerCaseFactory;
    private readonly IFactory<MotherBoard> _motherboardFactory;
    private readonly IFactory<WiFiAdapter> _wiFiAdapterFactory;

    public ComputerComponentsFactory(IFactory<Cpu> cpuFactory, IFactory<CpuCoolingSystem> cpuCoolingSystemFactory, IFactory<Ram> ramFactory, IFactory<Ssd> ssdFactory, IFactory<Hdd> hddFactory, IFactory<Gpu> gpuFactory, IFactory<PowerSupply> powerSupplyFactory, IFactory<ComputerCase> computerCaseFactory, IFactory<MotherBoard> motherboardFactory, IFactory<WiFiAdapter> wiFiAdapterFactory)
    {
        _cpuFactory = cpuFactory;
        _cpuCoolingSystemFactory = cpuCoolingSystemFactory;
        _ramFactory = ramFactory;
        _ssdFactory = ssdFactory;
        _hddFactory = hddFactory;
        _gpuFactory = gpuFactory;
        _powerSupplyFactory = powerSupplyFactory;
        _computerCaseFactory = computerCaseFactory;
        _motherboardFactory = motherboardFactory;
        _wiFiAdapterFactory = wiFiAdapterFactory;
    }

    public Cpu? CreateCpuByName(string name)
    {
        return _cpuFactory.CreateByName(name);
    }

    public ComputerCase? CreateComputerCaseByName(string name)
    {
        return _computerCaseFactory.CreateByName(name);
    }

    public Gpu? CreateGpuByName(string name)
    {
        return _gpuFactory.CreateByName(name);
    }

    public Hdd? CreateHddByName(string name)
    {
        return _hddFactory.CreateByName(name);
    }

    public Ssd? CreateSsdByName(string name)
    {
        return _ssdFactory.CreateByName(name);
    }

    public Ram? CreateRamByName(string name)
    {
        return _ramFactory.CreateByName(name);
    }

    public PowerSupply? CreatePowerSupplyByName(string name)
    {
        return _powerSupplyFactory.CreateByName(name);
    }

    public WiFiAdapter? CreateWiFiAdapterByName(string name)
    {
        return _wiFiAdapterFactory.CreateByName(name);
    }

    public CpuCoolingSystem? CreateCpuCoolingSystemByName(string name)
    {
        return _cpuCoolingSystemFactory.CreateByName(name);
    }

    public MotherBoard? CreateMotherBoardByName(string name)
    {
        return _motherboardFactory.CreateByName(name);
    }
}