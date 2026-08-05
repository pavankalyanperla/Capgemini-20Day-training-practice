using System;

class Program
{
    static int FibonacciSearch(int[] arr, int key)
    {
        int n = arr.Length;

        int fib2 = 0;
        int fib1 = 1;
        int fib = fib1 + fib2;

        while (fib < n)
        {
            fib2 = fib1;
            fib1 = fib;
            fib = fib1 + fib2;
        }

        int offset = -1;

        while (fib > 1)
        {
            int i = Math.Min(offset + fib2, n - 1);

            if (arr[i] < key)
            {
                fib = fib1;
                fib1 = fib2;
                fib2 = fib - fib1;
                offset = i;
            }
            else if (arr[i] > key)
            {
                fib = fib2;
                fib1 -= fib2;
                fib2 = fib - fib1;
            }
            else
            {
                return i;
            }
        }

        if (fib1 == 1 && offset + 1 < n && arr[offset + 1] == key)
            return offset + 1;

        return -1;
    }

    static void Main()
    {
        int[] arr = {1,3,8,15,29,33,46,60,71,92};

        Console.WriteLine(FibonacciSearch(arr, 46));
    }
}