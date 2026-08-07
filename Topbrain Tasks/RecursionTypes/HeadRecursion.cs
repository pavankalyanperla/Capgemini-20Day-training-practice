using System;

public class HeadRecursion
{
    public static void PrintAscending(int n)
    {
        if (n == 0)
            return;

        PrintAscending(n - 1);

        Console.Write(n + " ");
    }
}