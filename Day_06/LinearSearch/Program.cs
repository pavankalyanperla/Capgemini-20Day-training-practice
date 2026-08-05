using System;
using System.Diagnostics;

class Program
{
    static int LinearSearch(int[] arr, int key)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == key)
                return i;
        }

        return -1;
    }

    static void PrintArray(int[] arr)
    {
        Console.Write("[");

        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]);

            if (i != arr.Length - 1)
                Console.Write(", ");
        }

        Console.WriteLine("]");
    }

    static void Main()
    {
        int[] arr = {29,3,71,15,92,8,46,33,60,1};

        int key = 46;

        Console.WriteLine("====================================");
        Console.WriteLine("Linear Search");
        Console.WriteLine("====================================");
        Console.WriteLine("Searches each element sequentially until the key is found.");
        Console.WriteLine("Complexity : O(n)");
        Console.WriteLine("Space      : O(1)");
        Console.WriteLine();

        Console.Write("Array  : ");
        PrintArray(arr);

        Console.WriteLine("Search : " + key);

        Stopwatch sw = Stopwatch.StartNew();

        int index = LinearSearch(arr, key);

        sw.Stop();

        Console.WriteLine();

        if(index != -1)
            Console.WriteLine("Element Found at Index : " + index);
        else
            Console.WriteLine("Element Not Found");

        Console.WriteLine("Elapsed : " + sw.Elapsed.TotalMilliseconds.ToString("F3") + " ms");
    }
}