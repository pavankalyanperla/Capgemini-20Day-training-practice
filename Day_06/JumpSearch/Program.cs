using System;
using System.Diagnostics;

class Program
{
    static int JumpSearch(int[] arr, int key)
    {
        int n = arr.Length;
        int step = (int)Math.Sqrt(n);
        int prev = 0;

        while (prev < n && arr[Math.Min(step, n) - 1] < key)
        {
            prev = step;
            step += (int)Math.Sqrt(n);

            if (prev >= n)
                return -1;
        }

        while (prev < Math.Min(step, n))
        {
            if (arr[prev] == key)
                return prev;

            prev++;
        }

        return -1;
    }

    static void PrintArray(int[] arr)
    {
        Console.WriteLine("[" + string.Join(", ", arr) + "]");
    }

    static void Main()
    {
        int[] arr = {1,3,8,15,29,33,46,60,71,92};
        int key = 46;

        Console.WriteLine("====================================");
        Console.WriteLine("Jump Search");
        Console.WriteLine("====================================");
        Console.WriteLine("Searches by jumping fixed steps and then performs linear search.");
        Console.WriteLine("Complexity : O(√n)");
        Console.WriteLine("Space      : O(1)");
        Console.WriteLine();

        Console.Write("Array  : ");
        PrintArray(arr);

        Console.WriteLine("Search : " + key);

        Stopwatch sw = Stopwatch.StartNew();

        int index = JumpSearch(arr, key);

        sw.Stop();

        Console.WriteLine();

        if (index != -1)
            Console.WriteLine("Element Found at Index : " + index);
        else
            Console.WriteLine("Element Not Found");

        Console.WriteLine("Elapsed : " + sw.Elapsed.TotalMilliseconds.ToString("F3") + " ms");
    }
}