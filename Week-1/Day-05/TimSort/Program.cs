using System;
using System.Diagnostics;

class Program
{
    const int RUN = 32;

    static void InsertionSort(int[] arr, int left, int right)
    {
        for (int i = left + 1; i <= right; i++)
        {
            int temp = arr[i];
            int j = i - 1;

            while (j >= left && arr[j] > temp)
            {
                arr[j + 1] = arr[j];
                j--;
            }

            arr[j + 1] = temp;
        }
    }

    static void Merge(int[] arr, int left, int mid, int right)
    {
        int len1 = mid - left + 1;
        int len2 = right - mid;

        int[] leftArr = new int[len1];
        int[] rightArr = new int[len2];

        for (int i = 0; i < len1; i++)
            leftArr[i] = arr[left + i];

        for (int i = 0; i < len2; i++)
            rightArr[i] = arr[mid + 1 + i];

        int x = 0, y = 0, k = left;

        while (x < len1 && y < len2)
        {
            if (leftArr[x] <= rightArr[y])
                arr[k++] = leftArr[x++];
            else
                arr[k++] = rightArr[y++];
        }

        while (x < len1)
            arr[k++] = leftArr[x++];

        while (y < len2)
            arr[k++] = rightArr[y++];
    }

    static void TimSort(int[] arr)
    {
        int n = arr.Length;

        // Sort small runs using Insertion Sort
        for (int i = 0; i < n; i += RUN)
        {
            int right = Math.Min(i + RUN - 1, n - 1);
            InsertionSort(arr, i, right);
        }

        // Merge runs
        for (int size = RUN; size < n; size *= 2)
        {
            for (int left = 0; left < n; left += 2 * size)
            {
                int mid = Math.Min(left + size - 1, n - 1);
                int right = Math.Min(left + 2 * size - 1, n - 1);

                if (mid < right)
                    Merge(arr, left, mid, right);
            }
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
        Console.WriteLine("Tim Sort");
        Console.WriteLine("====================================");
        Console.WriteLine("Combines Insertion Sort and Merge Sort by sorting small runs and then merging them.");
        Console.WriteLine("Complexity : O(n) best, O(n log n) average/worst");
        Console.WriteLine("Space      : O(n)");
        Console.WriteLine("Stable     : True");
        Console.WriteLine();

        Console.Write("Before : ");
        PrintArray(arr);

        Stopwatch sw = Stopwatch.StartNew();

        TimSort(arr);

        sw.Stop();

        Console.Write("After  : ");
        PrintArray(arr);

        Console.WriteLine();
        Console.WriteLine("Valid Sort : " + IsSorted(arr));
        Console.WriteLine("Elapsed    : " + sw.Elapsed.TotalMilliseconds.ToString("F3") + " ms");
        Console.WriteLine("Allocated  : N/A");
    }
}