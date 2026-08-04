using System;
using System.Diagnostics;

class Program
{
    static void SelectionSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int min = i;

            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[min])
                    min = j;
            }

            int temp = arr[i];
            arr[i] = arr[min];
            arr[min] = temp;
        }
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
        Console.Write("[");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]);
            if (i < arr.Length - 1)
                Console.Write(", ");
        }
        Console.WriteLine("]");
    }

    static void Main()
    {
        int[] arr = { 29, 3, 71, 15, 92, 8, 46, 33, 60, 1 };

        Console.WriteLine("====================================");
        Console.WriteLine("Selection Sort");
        Console.WriteLine("====================================");
        Console.WriteLine("Selects the smallest element and places it in its correct position.");
        Console.WriteLine("Complexity : O(n²) best/average/worst");
        Console.WriteLine("Space      : O(1)");
        Console.WriteLine("Stable     : False\n");

        Console.Write("Before : ");
        PrintArray(arr);

        Stopwatch sw = Stopwatch.StartNew();
        SelectionSort(arr);
        sw.Stop();

        Console.Write("After  : ");
        PrintArray(arr);

        Console.WriteLine("\nValid Sort : " + IsSorted(arr));
        Console.WriteLine("Elapsed    : " + sw.Elapsed.TotalMilliseconds.ToString("F3") + " ms");
        Console.WriteLine("Allocated  : N/A");
    }
}