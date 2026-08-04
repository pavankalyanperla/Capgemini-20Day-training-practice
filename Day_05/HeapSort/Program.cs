using System;
using System.Diagnostics;

class Program
{
    static void HeapSort(int[] arr)
    {
        int n = arr.Length;

        // Build Max Heap
        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(arr, n, i);

        // Extract elements one by one
        for (int i = n - 1; i > 0; i--)
        {
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            Heapify(arr, i, 0);
        }
    }

    static void Heapify(int[] arr, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && arr[left] > arr[largest])
            largest = left;

        if (right < n && arr[right] > arr[largest])
            largest = right;

        if (largest != i)
        {
            int temp = arr[i];
            arr[i] = arr[largest];
            arr[largest] = temp;

            Heapify(arr, n, largest);
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
        Console.WriteLine("Heap Sort");
        Console.WriteLine("====================================");
        Console.WriteLine("Builds a max heap and repeatedly places the largest element at the end.");
        Console.WriteLine("Complexity : O(n log n) best/average/worst");
        Console.WriteLine("Space      : O(1)");
        Console.WriteLine("Stable     : False");
        Console.WriteLine();

        Console.Write("Before : ");
        PrintArray(arr);

        Stopwatch sw = Stopwatch.StartNew();

        HeapSort(arr);

        sw.Stop();

        Console.Write("After  : ");
        PrintArray(arr);

        Console.WriteLine();
        Console.WriteLine("Valid Sort : " + IsSorted(arr));
        Console.WriteLine("Elapsed    : " + sw.Elapsed.TotalMilliseconds.ToString("F3") + " ms");
        Console.WriteLine("Allocated  : N/A");
    }
}