using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class Factory<T> : IFactory<T>
    where T : INameble, ICloneable<T>
{
    private readonly ICollection<T> _list;

    public Factory(ICollection<T> list)
    {
        _list = list;
    }

    public T? CreateByName(string name)
    {
        T? var = _list.FirstOrDefault(obj => obj.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (var is null)
        {
            return default;
        }

        return var.Clone();
    }
}