using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Dictionary<int, string> students = new Dictionary<int, string>();

        students.Add(101, "John");
        students.Add(102, "Alice");
        students.Add(103, "David");
        students.Add(104, "Emma");
        students.Add(105, "James");

        int key = 103;

        Console.WriteLine("====================================");
        Console.WriteLine("Hash Search");
        Console.WriteLine("====================================");
        Console.WriteLine("Uses a Hash Table (Dictionary) for fast lookup.");
        Console.WriteLine("Complexity : O(1) Average");
        Console.WriteLine("Space      : O(n)");
        Console.WriteLine();

        Stopwatch sw = Stopwatch.StartNew();

        bool found = students.TryGetValue(key, out string name);

        sw.Stop();

        Console.WriteLine("Search Key : " + key);

        Console.WriteLine();

        if (found)
            Console.WriteLine("Student Found : " + name);
        else
            Console.WriteLine("Student Not Found");

        Console.WriteLine("Elapsed : " + sw.Elapsed.TotalMilliseconds.ToString("F3") + " ms");
    }
}