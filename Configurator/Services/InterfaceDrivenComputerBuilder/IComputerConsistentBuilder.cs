using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public interface IComputerConsistentBuilder : IBuildble, ICpuBuilder, IMotherBoardBuilder, ICpuCoolingSystemBuilder, IRamBuilder, IAdditionalMemoryBuilder, IGpuBuilder, IComputerCaseBuilder, IPowerSupplyBuilder
{
    public IComputerConsistentBuilder YouCanAddWiFiAdapter(WiFiAdapter? wiFiAdapter);
}