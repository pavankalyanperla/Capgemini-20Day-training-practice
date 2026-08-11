using System;
using System.Diagnostics;
using System.Text;

class Program
{
    // Build using normal string concatenation
    static string BuildWithString(int count)
    {
        string result = "";

        for (int i = 0; i < count; i++)
        {
            result += i.ToString();
        }

        return result;
    }

    // Build using StringBuilder
    static string BuildWithStringBuilder(int count)
    {
        // Pre-size the capacity to reduce memory reallocations
        StringBuilder result = new StringBuilder(count * 2);

        for (int i = 0; i < count; i++)
        {
            result.Append(i.ToString());
        }

        return result.ToString();
    }

    static void Main()
    {
        int count = 50000;

        Console.WriteLine("======================================");
        Console.WriteLine("   String vs StringBuilder Benchmark");
        Console.WriteLine("======================================");
        Console.WriteLine();

        // -------------------------------
        // String concatenation
        // -------------------------------

        Stopwatch stopwatch = Stopwatch.StartNew();

        string stringResult = BuildWithString(count);

        stopwatch.Stop();

        long stringTime = stopwatch.ElapsedMilliseconds;

        // -------------------------------
        // StringBuilder
        // -------------------------------

        stopwatch.Restart();

        string stringBuilderResult = BuildWithStringBuilder(count);

        stopwatch.Stop();

        long stringBuilderTime = stopwatch.ElapsedMilliseconds;

        // Prevent compiler from completely ignoring the results
        Console.WriteLine("Result length: " + stringResult.Length);
        Console.WriteLine();

        Console.WriteLine(
            $"String concatenation ({count:N0} items): {stringTime} ms"
        );

        Console.WriteLine(
            $"StringBuilder ({count:N0} items):          {stringBuilderTime} ms"
        );

        // -------------------------------
        // Calculate ratio
        // -------------------------------

        if (stringBuilderTime > 0)
        {
            double ratio =
                (double)stringTime / stringBuilderTime;

            Console.WriteLine();
            Console.WriteLine(
                $"String / StringBuilder ratio: {ratio:F2}x"
            );
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine(
                "StringBuilder completed too quickly to calculate ratio."
            );
        }

        // -------------------------------
        // Second test
        // -------------------------------

        Console.WriteLine();
        Console.WriteLine("======================================");
        Console.WriteLine("       Second Test: 200,000");
        Console.WriteLine("======================================");
        Console.WriteLine();

        count = 200000;

        stopwatch.Restart();

        stringResult = BuildWithString(count);

        stopwatch.Stop();

        stringTime = stopwatch.ElapsedMilliseconds;

        stopwatch.Restart();

        stringBuilderResult = BuildWithStringBuilder(count);

        stopwatch.Stop();

        stringBuilderTime = stopwatch.ElapsedMilliseconds;

        Console.WriteLine(
            $"String concatenation ({count:N0} items): {stringTime} ms"
        );

        Console.WriteLine(
            $"StringBuilder ({count:N0} items):          {stringBuilderTime} ms"
        );

        if (stringBuilderTime > 0)
        {
            double ratio =
                (double)stringTime / stringBuilderTime;

            Console.WriteLine();
            Console.WriteLine(
                $"String / StringBuilder ratio: {ratio:F2}x"
            );
        }
    }
}