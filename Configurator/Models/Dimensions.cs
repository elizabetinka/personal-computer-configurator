using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Dimensions
{
    public Dimensions(int lenght, int width, int height)
    {
        if (lenght < 0 || width < 0 || height < 0)
        {
            throw new ArgumentException("Не валидные аргументы");
        }

        Lenght = lenght;
        Width = width;
        Height = height;
    }

    public int Lenght { get; }
    public int Width { get; }
    public int Height { get; }

    public bool Less(Dimensions rhs)
    {
        rhs = rhs ?? throw new ArgumentNullException(nameof(rhs));
        return Height < rhs.Height && Lenght < rhs.Lenght && Width < rhs.Width;
    }
}