using Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public interface IComputerDebuilderDirector
{
    public IOrdinaryComputerBuilder Debuilder(IOrdinaryComputerBuilder builder);
}