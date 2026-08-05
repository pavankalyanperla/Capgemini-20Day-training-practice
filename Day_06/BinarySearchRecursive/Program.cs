using System;
using System.Diagnostics;

class Program
{
    static int BinarySearch(int[] arr, int left, int right, int key)
    {
        if(left > right)
            return -1;

        int mid = (left + right) / 2;

        if(arr[mid] == key)
            return mid;

        if(key < arr[mid])
            return BinarySearch(arr,left,mid-1,key);

        return BinarySearch(arr,mid+1,right,key);
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
        Console.WriteLine("Binary Search (Recursive)");
        Console.WriteLine("====================================");
        Console.WriteLine("Uses recursion to repeatedly divide the sorted array.");
        Console.WriteLine("Complexity : O(log n)");
        Console.WriteLine("Space      : O(log n)");
        Console.WriteLine();

        Console.Write("Array  : ");
        PrintArray(arr);

        Console.WriteLine("Search : " + key);

        Stopwatch sw = Stopwatch.StartNew();

        int index = BinarySearch(arr,0,arr.Length-1,key);

        sw.Stop();

        Console.WriteLine();

        if(index != -1)
            Console.WriteLine("Element Found at Index : " + index);
        else
            Console.WriteLine("Element Not Found");

        Console.WriteLine("Elapsed : " + sw.Elapsed.TotalMilliseconds.ToString("F3") + " ms");
    }
}