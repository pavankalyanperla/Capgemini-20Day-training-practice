using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("===== HEAD RECURSION =====");
        HeadRecursion.PrintAscending(5);

        Console.WriteLine("\n\n===== TAIL RECURSION =====");
        TailRecursion.PrintDescending(5);

        Console.WriteLine("\n\n===== TREE RECURSION =====");
        Console.WriteLine("Fibonacci(5) = " + TreeRecursion.Fibonacci(5));

        Console.WriteLine("\n===== INDIRECT RECURSION =====");
        IndirectRecursion.Even(5);
    }
}