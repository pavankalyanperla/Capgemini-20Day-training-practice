using System;
using System.Diagnostics;

class Program
{
    static void InsertionSort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }

            arr[j + 1] = key;
        }
    }

    static bool IsSorted(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < arr[i - 1])
                return false;
        }

        return true;
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
        int[] arr = { 29, 3, 71, 15, 92, 8, 46, 33, 60, 1 };

        Console.WriteLine("====================================");
        Console.WriteLine("Insertion Sort");
        Console.WriteLine("====================================");
        Console.WriteLine("Builds a sorted prefix by inserting each new element into its correct position.");
        Console.WriteLine("Complexity : O(n) best, O(n²) average/worst");
        Console.WriteLine("Space      : O(1)");
        Console.WriteLine("Stable     : True");
        Console.WriteLine();

        Console.Write("Before : ");
        PrintArray(arr);

        Stopwatch sw = Stopwatch.StartNew();

        InsertionSort(arr);

        sw.Stop();

        Console.Write("After  : ");
        PrintArray(arr);

        Console.WriteLine();

        Console.WriteLine("Valid Sort : " + IsSorted(arr));
        Console.WriteLine("Elapsed    : " + sw.Elapsed.TotalMilliseconds.ToString("F3") + " ms");
        Console.WriteLine("Allocated  : N/A");
    }
}