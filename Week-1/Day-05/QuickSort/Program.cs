using System;
using System.Diagnostics;

class Program
{
    static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int p = Partition(arr, low, high);

            QuickSort(arr, low, p - 1);
            QuickSort(arr, p + 1, high);
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;

                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        int t = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = t;

        return i + 1;
    }

    static bool IsSorted(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
            if (arr[i] < arr[i - 1])
                return false;

        return true;
    }

    static void PrintArray(int[] arr)
    {
        Console.WriteLine("[" + string.Join(", ", arr) + "]");
    }

    static void Main()
    {
        int[] arr = { 29, 3, 71, 15, 92, 8, 46, 33, 60, 1 };

        Console.WriteLine("====================================");
        Console.WriteLine("Quick Sort");
        Console.WriteLine("====================================");
        Console.WriteLine("Partitions the array around a pivot and recursively sorts each partition.");
        Console.WriteLine("Complexity : O(n log n) best/average, O(n²) worst");
        Console.WriteLine("Space      : O(log n)");
        Console.WriteLine("Stable     : False\n");

        Console.Write("Before : ");
        PrintArray(arr);

        Stopwatch sw = Stopwatch.StartNew();
        QuickSort(arr, 0, arr.Length - 1);
        sw.Stop();

        Console.Write("After  : ");
        PrintArray(arr);

        Console.WriteLine("\nValid Sort : " + IsSorted(arr));
        Console.WriteLine("Elapsed    : " + sw.Elapsed.TotalMilliseconds.ToString("F3") + " ms");
        Console.WriteLine("Allocated  : N/A");
    }
}