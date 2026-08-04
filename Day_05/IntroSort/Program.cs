using System;
using System.Diagnostics;

class Program
{
    const int INSERTION_SORT_THRESHOLD = 16;

    static void IntroSort(int[] arr)
    {
        int depthLimit = 2 * (int)Math.Log(arr.Length, 2);
        IntroSort(arr, 0, arr.Length - 1, depthLimit);
    }

    static void IntroSort(int[] arr, int low, int high, int depthLimit)
    {
        int size = high - low + 1;

        // Small array -> Insertion Sort
        if (size <= INSERTION_SORT_THRESHOLD)
        {
            InsertionSort(arr, low, high);
            return;
        }

        // Too much recursion -> Heap Sort
        if (depthLimit == 0)
        {
            HeapSort(arr, low, high);
            return;
        }

        int pivot = Partition(arr, low, high);

        IntroSort(arr, low, pivot - 1, depthLimit - 1);
        IntroSort(arr, pivot + 1, high, depthLimit - 1);
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
                Swap(arr, i, j);
            }
        }

        Swap(arr, i + 1, high);

        return i + 1;
    }

    static void InsertionSort(int[] arr, int low, int high)
    {
        for (int i = low + 1; i <= high; i++)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= low && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }

            arr[j + 1] = key;
        }
    }

    static void HeapSort(int[] arr, int low, int high)
    {
        int n = high - low + 1;

        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(arr, n, i, low);

        for (int i = n - 1; i > 0; i--)
        {
            Swap(arr, low, low + i);
            Heapify(arr, i, 0, low);
        }
    }

    static void Heapify(int[] arr, int n, int i, int offset)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && arr[offset + left] > arr[offset + largest])
            largest = left;

        if (right < n && arr[offset + right] > arr[offset + largest])
            largest = right;

        if (largest != i)
        {
            Swap(arr, offset + i, offset + largest);
            Heapify(arr, n, largest, offset);
        }
    }

    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
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
        Console.WriteLine("Introspective Sort (Introsort)");
        Console.WriteLine("====================================");
        Console.WriteLine("Starts with Quick Sort, switches to Heap Sort if recursion is too deep,");
        Console.WriteLine("and uses Insertion Sort for small partitions.");
        Console.WriteLine("Complexity : O(n log n) best/average/worst");
        Console.WriteLine("Space      : O(log n)");
        Console.WriteLine("Stable     : False");
        Console.WriteLine();

        Console.Write("Before : ");
        PrintArray(arr);

        Stopwatch sw = Stopwatch.StartNew();

        IntroSort(arr);

        sw.Stop();

        Console.Write("After  : ");
        PrintArray(arr);

        Console.WriteLine();
        Console.WriteLine("Valid Sort : " + IsSorted(arr));
        Console.WriteLine("Elapsed    : " + sw.Elapsed.TotalMilliseconds.ToString("F3") + " ms");
        Console.WriteLine("Allocated  : N/A");
    }
}