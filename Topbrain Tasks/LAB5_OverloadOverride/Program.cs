// Lab 5: Overload vs Override vs Hide vs Operator Overload

using System;

// ── 1. METHOD OVERLOADING ──────────────────────────────────────────────────
// Same method name, different parameter signatures — resolved at COMPILE TIME
public class Formatter
{
    public string Format(int value) => value.ToString();

    public string Format(double value) => value.ToString("F2");

    // Treat two ints as a fraction: numerator / denominator
    public string Format(int numerator, int denominator) => $"{numerator}/{denominator}";
}

// ── 2. OVERRIDE vs HIDE ───────────────────────────────────────────────────
// virtual + override → runtime dispatch (actual object type wins)
// non-virtual + new  → compile-time dispatch (declared variable type wins)
public class Notifier
{
    public virtual void Send() => Console.WriteLine("Notifier: generic send");
    public void Log()          => Console.WriteLine("Notifier: generic log");
}

public class EmailNotifier : Notifier
{
    // override: replaces Send() at runtime — polymorphic
    public override void Send() => Console.WriteLine("EmailNotifier: sending email");

    // new (hide): only visible when variable is declared as EmailNotifier
    public new void Log() => Console.WriteLine("EmailNotifier: logging to email log");
}

// ── 3. OPERATOR OVERLOADING ───────────────────────────────────────────────
public struct Vector2
{
    public double X, Y;

    public Vector2(double x, double y) { X = x; Y = y; }

    // Vector + Vector
    public static Vector2 operator +(Vector2 a, Vector2 b)
        => new Vector2(a.X + b.X, a.Y + b.Y);

    // Vector * scalar  (scalar * Vector handled by the second overload)
    public static Vector2 operator *(Vector2 v, double scalar)
        => new Vector2(v.X * scalar, v.Y * scalar);

    public static Vector2 operator *(double scalar, Vector2 v)
        => v * scalar;

    // Bonus: == and != with matching Equals / GetHashCode
    public static bool operator ==(Vector2 a, Vector2 b)
        => a.X == b.X && a.Y == b.Y;

    public static bool operator !=(Vector2 a, Vector2 b)
        => !(a == b);

    public override bool Equals(object obj)
        => obj is Vector2 other && this == other;

    public override int GetHashCode() => HashCode.Combine(X, Y);

    public override string ToString() => $"({X}, {Y})";
}

public class Lab5
{
    public static void Main()
    {
        // ── Overloads ─────────────────────────────────────────────────────
        var fmt = new Formatter();
        Console.WriteLine($"Format(7)    -> \"{fmt.Format(7)}\"");
        Console.WriteLine($"Format(3.5)  -> \"{fmt.Format(3.5)}\"");
        Console.WriteLine($"Format(3, 4) -> \"{fmt.Format(3, 4)}\"");

        Console.WriteLine();

        // ── Override vs Hide ──────────────────────────────────────────────
        EmailNotifier email   = new EmailNotifier();  // declared as EmailNotifier
        Notifier      generic = email;                // same object, declared as Notifier

        Console.WriteLine("-- through EmailNotifier variable --");
        email.Send();   // override → EmailNotifier wins
        email.Log();    // hide (new) → EmailNotifier version visible

        Console.WriteLine("-- through Notifier variable, same object --");
        generic.Send(); // override → runtime type still wins: EmailNotifier
        generic.Log();  // hide → declared type wins: Notifier

        Console.WriteLine();

        // ── Operator overloading ──────────────────────────────────────────
        var v1 = new Vector2(1, 2);
        var v2 = new Vector2(3, 4);
        var v3 = new Vector2(2, 2);

        Console.WriteLine($"{v1} + {v2} = {v1 + v2}");
        Console.WriteLine($"{v3} * 3 = {v3 * 3}");

        // Bonus: == and !=
        Console.WriteLine();
        var a = new Vector2(5, 5);
        var b = new Vector2(5, 5);
        Console.WriteLine($"(5,5) == (5,5) -> {a == b}");
        Console.WriteLine($"(5,5) != (1,2) -> {a != v1}");
    }
}