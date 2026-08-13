using System;
using System.Diagnostics;

class Program
{
    static int InterpolationSearch(int[] arr, int key)
    {
        int low = 0;
        int high = arr.Length - 1;

        while (low <= high && key >= arr[low] && key <= arr[high])
        {
            if (low == high)
            {
                if (arr[low] == key)
                    return low;
                return -1;
            }

            int pos = low + ((key - arr[low]) * (high - low)) /
                             (arr[high] - arr[low]);

            if (arr[pos] == key)
                return pos;

            if (arr[pos] < key)
                low = pos + 1;
            else
                high = pos - 1;
        }

        return -1;
    }

    static void Main()
    {
        int[] arr = {10,20,30,40,50,60,70,80,90,100};
        int key = 70;

        Console.WriteLine("====================================");
        Console.WriteLine("Interpolation Search");
        Console.WriteLine("====================================");

        Stopwatch sw = Stopwatch.StartNew();

        int index = InterpolationSearch(arr, key);

        sw.Stop();

        Console.WriteLine("Found at Index : " + index);
        Console.WriteLine("Elapsed : " + sw.Elapsed.TotalMilliseconds.ToString("F3") + " ms");
    }
}