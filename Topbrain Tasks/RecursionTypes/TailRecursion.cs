using System;

public class TailRecursion
{
    public static void PrintDescending(int n)
    {
        if (n == 0)
            return;

        Console.Write(n + " ");

        PrintDescending(n - 1);
    }
}