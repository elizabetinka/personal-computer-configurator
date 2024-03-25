using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public enum ComputerStatus
{
    Good,
    Disclaimer,
    IncreasedPowerConsumption,
    NotWork,
}

public class ComputerResultStatus : ICloneable<ComputerResultStatus>
{
    public ComputerResultStatus(ComputerStatus computerStatus)
    {
        ComputerStatus = computerStatus;
        ProblemLogs = new List<string>();
    }

    public ComputerResultStatus(ComputerStatus computerStatus, ICollection<string> problemLogs)
    {
        ComputerStatus = computerStatus;
        ProblemLogs = problemLogs;
    }

    public ComputerStatus ComputerStatus { get; set; }

    public ICollection<string> ProblemLogs { get; }

    public void AddProblemLogs(string component)
    {
        if (!ProblemLogs.Any(a => a == component))
        {
            ProblemLogs.Add(component);
        }
    }

    public bool AmIGoToSalesDepartment()
    {
        return ComputerStatus != ComputerStatus.NotWork;
    }

    public void ClearLogs()
    {
        ProblemLogs.Clear();
    }

    public ComputerResultStatus Clone()
    {
        return new ComputerResultStatus(ComputerStatus, ProblemLogs);
    }
}