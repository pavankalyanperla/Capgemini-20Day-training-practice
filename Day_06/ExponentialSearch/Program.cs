using System;
using System.Diagnostics;

class Program
{
    static int BinarySearch(int[] arr, int left, int right, int key)
    {
        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (arr[mid] == key)
                return mid;

            if (arr[mid] < key)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }

    static int ExponentialSearch(int[] arr, int key)
    {
        if (arr[0] == key)
            return 0;

        int i = 1;

        while (i < arr.Length && arr[i] <= key)
            i *= 2;

        return BinarySearch(arr, i / 2, Math.Min(i, arr.Length - 1), key);
    }

    static void Main()
    {
        int[] arr = {1,3,8,15,29,33,46,60,71,92};

        int key = 60;

        Stopwatch sw = Stopwatch.StartNew();

        int index = ExponentialSearch(arr, key);

        sw.Stop();

        Console.WriteLine("Found at Index : " + index);
        Console.WriteLine("Elapsed : " + sw.Elapsed.TotalMilliseconds.ToString("F3") + " ms");
    }
}