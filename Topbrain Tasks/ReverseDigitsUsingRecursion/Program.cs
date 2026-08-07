using System;

class Program
{
    static void SumDigitsReversed(int n)
    {
        if (n == 0)
            return;

        Console.Write(n % 10 + " ");

        SumDigitsReversed(n / 10);
    }

    static void Main()
    {
        int n = 12345;

        Console.Write("Digits in reverse order: ");
        SumDigitsReversed(n);
    }
}