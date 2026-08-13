using System;
using System.Diagnostics;

class Program
{
    static int SentinelSearch(int[] arr, int key)
    {
        int n = arr.Length;

        int last = arr[n - 1];

        arr[n - 1] = key;

        int i = 0;

        while (arr[i] != key)
            i++;

        arr[n - 1] = last;

        if (i < n - 1 || last == key)
            return i;

        return -1;
    }

    static void PrintArray(int[] arr)
    {
        Console.Write("[");

        for(int i=0;i<arr.Length;i++)
        {
            Console.Write(arr[i]);

            if(i != arr.Length-1)
                Console.Write(", ");
        }

        Console.WriteLine("]");
    }

    static void Main()
    {
        int[] arr = {29,3,71,15,92,8,46,33,60,1};

        int key = 46;

        Console.WriteLine("====================================");
        Console.WriteLine("Sentinel Linear Search");
        Console.WriteLine("====================================");
        Console.WriteLine("Uses the last element as a sentinel to reduce comparisons.");
        Console.WriteLine("Complexity : O(n)");
        Console.WriteLine("Space      : O(1)");
        Console.WriteLine();

        Console.Write("Array  : ");
        PrintArray(arr);

        Console.WriteLine("Search : " + key);

        Stopwatch sw = Stopwatch.StartNew();

        int index = SentinelSearch(arr,key);

        sw.Stop();

        Console.WriteLine();

        if(index != -1)
            Console.WriteLine("Element Found at Index : " + index);
        else
            Console.WriteLine("Element Not Found");

        Console.WriteLine("Elapsed : " + sw.Elapsed.TotalMilliseconds.ToString("F3") + " ms");
    }
}