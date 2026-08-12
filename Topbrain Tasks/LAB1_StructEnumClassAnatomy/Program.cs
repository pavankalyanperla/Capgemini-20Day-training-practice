// Lab 1: Structs, Enums & Class Anatomy

using System;

public struct RgbColor
{
    public byte R, G, B;

    public RgbColor(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }

    public override string ToString() => $"#{R:X2}{G:X2}{B:X2}";
}

public enum NamedColor { Red, Green, Blue, White, Black }

public class Pixel
{
    public RgbColor Color;
}

// Bonus: [Flags] enum for non-zero channels
[Flags]
public enum ColorChannels { None = 0, R = 1, G = 2, B = 4 }

public class Lab1
{
    public static RgbColor FromNamed(NamedColor name) => name switch
    {
        NamedColor.Red   => new RgbColor(255, 0, 0),
        NamedColor.Green => new RgbColor(0, 255, 0),
        NamedColor.Blue  => new RgbColor(0, 0, 255),
        NamedColor.White => new RgbColor(255, 255, 255),
        NamedColor.Black => new RgbColor(0, 0, 0),
        _                => throw new ArgumentOutOfRangeException(nameof(name))
    };

    // Bonus: returns which channels are non-zero
    public static ColorChannels ActiveChannels(RgbColor color)
    {
        var channels = ColorChannels.None;
        if (color.R != 0) channels |= ColorChannels.R;
        if (color.G != 0) channels |= ColorChannels.G;
        if (color.B != 0) channels |= ColorChannels.B;
        return channels;
    }

    public static void Run()
    {
        // --- struct copy semantics ---
        Console.WriteLine("-- struct copy --");
        RgbColor a = FromNamed(NamedColor.Red);
        RgbColor b = a;          // value copy: b is independent
        b.R = 1;                 // only b changes
        Console.WriteLine($"a = {a}");
        Console.WriteLine($"b = {b}   (only b changed, a is unaffected)");

        Console.WriteLine();

        // --- class/reference copy semantics ---
        Console.WriteLine("-- class/reference copy --");
        Pixel p1 = new Pixel { Color = FromNamed(NamedColor.Green) };
        Pixel p2 = p1;           // reference copy: same Pixel object
        p2.Color = FromNamed(NamedColor.Blue);   // mutates the shared object
        Console.WriteLine($"p1.Color = {p1.Color}");
        Console.WriteLine($"p2.Color = {p2.Color}   (both changed - same underlying Pixel object)");

        Console.WriteLine();

        // Bonus: active channels
        Console.WriteLine("-- bonus: active channels --");
        Console.WriteLine($"Red channels: {ActiveChannels(FromNamed(NamedColor.Red))}");
        Console.WriteLine($"White channels: {ActiveChannels(FromNamed(NamedColor.White))}");
        Console.WriteLine($"Black channels: {ActiveChannels(FromNamed(NamedColor.Black))}");
    }

    public static void Main() => Run();
}