namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IAdditionalMemory : IEnergyConsuming
{
    int StorageSize { get; }
    public ConnectionOption Connection { get; init; }
}