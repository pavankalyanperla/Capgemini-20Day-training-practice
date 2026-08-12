// Lab 6: Capstone — Shape Hierarchy

using System;
using System.Collections.Generic;
using System.Linq;

// ── 1. ENUM ───────────────────────────────────────────────────────────────
public enum ShapeKind { Circle, Rectangle, Triangle }

// ── 2. ABSTRACT BASE CLASS ────────────────────────────────────────────────
// Bonus: implements IComparable<Shape> so shapes can be sorted by area
public abstract class Shape : IComparable<Shape>
{
    public ShapeKind Kind { get; protected set; }

    public abstract double Area();
    public abstract double Perimeter();

    // Concrete ToString() — works for every subclass via polymorphism
    public override string ToString() =>
        $"{Kind}: Area={Area():F2}, Perimeter={Perimeter():F2}";

    // Bonus: IComparable — ascending area sort
    public int CompareTo(Shape other) => Area().CompareTo(other.Area());
}

// ── 3. CIRCLE ─────────────────────────────────────────────────────────────
public class Circle : Shape
{
    private readonly double _radius;

    public Circle(double radius)
    {
        Kind    = ShapeKind.Circle;
        _radius = radius;
    }

    public override double Area()      => Math.PI * _radius * _radius;
    public override double Perimeter() => 2 * Math.PI * _radius;
}

// ── 4. RECTANGLE ──────────────────────────────────────────────────────────
public class Rectangle : Shape
{
    private readonly double _width, _height;

    public Rectangle(double width, double height)
    {
        Kind    = ShapeKind.Rectangle;
        _width  = width;
        _height = height;
    }

    public override double Area()      => _width * _height;
    public override double Perimeter() => 2 * (_width + _height);
}

// ── 5. TRIANGLE (Heron's formula) ─────────────────────────────────────────
public class Triangle : Shape
{
    private readonly double _a, _b, _c;

    public Triangle(double a, double b, double c)
    {
        if (a + b <= c || a + c <= b || b + c <= a)
            throw new ArgumentException("Sides do not form a valid triangle.");

        Kind = ShapeKind.Triangle;
        _a = a; _b = b; _c = c;
    }

    public override double Perimeter() => _a + _b + _c;

    public override double Area()
    {
        // Heron's formula: Area = √(s(s-a)(s-b)(s-c))  where s = semi-perimeter
        double s = Perimeter() / 2;
        return Math.Sqrt(s * (s - _a) * (s - _b) * (s - _c));
    }
}

// ── 6. BOUNDING BOX STRUCT ────────────────────────────────────────────────
public struct BoundingBox
{
    public double Width, Height;

    public BoundingBox(double w, double h) { Width = w; Height = h; }

    // Operator *: scale both dimensions by a factor
    public static BoundingBox operator *(BoundingBox box, double factor)
        => new BoundingBox(box.Width * factor, box.Height * factor);

    // Bonus: Deconstruct so `var (w, h) = box;` works
    public void Deconstruct(out double width, out double height)
    {
        width  = Width;
        height = Height;
    }

    public override string ToString() => $"({Width}, {Height})";
}

// ── 7. SHAPEMATH — OVERLOADED STATIC METHODS ─────────────────────────────
public static class ShapeMath
{
    // All shapes
    public static double TotalArea(IEnumerable<Shape> shapes)
        => shapes.Sum(s => s.Area());

    // Filtered by kind
    public static double TotalArea(IEnumerable<Shape> shapes, ShapeKind onlyKind)
        => shapes.Where(s => s.Kind == onlyKind).Sum(s => s.Area());
}

// ── DRIVER ────────────────────────────────────────────────────────────────
public class Lab6
{
    public static void Main()
    {
        var shapes = new List<Shape>
        {
            new Circle(3),
            new Rectangle(4, 6),
            new Triangle(3, 4, 5)   // right-angled: area = 6, perimeter = 12
        };

        // Bonus: sort by area ascending before printing
        shapes.Sort();

        Console.WriteLine("-- shapes (sorted by area ascending) --");
        foreach (var shape in shapes)
            Console.WriteLine(shape);   // polymorphic ToString()

        Console.WriteLine();
        Console.WriteLine($"Total area (all shapes):    {ShapeMath.TotalArea(shapes):F2}");
        Console.WriteLine($"Total area (circles only):  {ShapeMath.TotalArea(shapes, ShapeKind.Circle):F2}");

        Console.WriteLine();

        // BoundingBox operator * and Deconstruct
        var box     = new BoundingBox(4, 3);
        var scaled  = box * 2;
        Console.WriteLine($"Scaled bounding box {box} * 2 -> {scaled}");

        // Bonus: deconstruct
        var (w, h) = scaled;
        Console.WriteLine($"Deconstructed: width={w}, height={h}");
    }
}