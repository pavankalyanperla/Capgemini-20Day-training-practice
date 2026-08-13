using System;
using System.Diagnostics;

class Program
{
    static int BinarySearch(int[] arr, int key)
    {
        int left = 0;
        int right = arr.Length - 1;

        while(left <= right)
        {
            int mid = (left + right) / 2;

            if(arr[mid] == key)
                return mid;

            if(arr[mid] < key)
                left = mid + 1;
            else
                right = mid - 1;
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
        Console.WriteLine("Binary Search (Iterative)");
        Console.WriteLine("====================================");
        Console.WriteLine("Repeatedly divides the sorted array into two halves.");
        Console.WriteLine("Complexity : O(log n)");
        Console.WriteLine("Space      : O(1)");
        Console.WriteLine();

        Console.Write("Array  : ");
        PrintArray(arr);

        Console.WriteLine("Search : " + key);

        Stopwatch sw = Stopwatch.StartNew();

        int index = BinarySearch(arr,key);

        sw.Stop();

        Console.WriteLine();

        if(index != -1)
            Console.WriteLine("Element Found at Index : " + index);
        else
            Console.WriteLine("Element Not Found");

        Console.WriteLine("Elapsed : " + sw.Elapsed.TotalMilliseconds.ToString("F3") + " ms");
    }
}