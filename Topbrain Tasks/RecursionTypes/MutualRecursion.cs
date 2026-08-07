using System;

public class IndirectRecursion
{
    public static void Even(int n)
    {
        if (n == 0)
        {
            Console.WriteLine("Finished");
            return;
        }

        Console.WriteLine("Even Function : " + n);

        Odd(n - 1);
    }

    public static void Odd(int n)
    {
        if (n == 0)
        {
            Console.WriteLine("Finished");
            return;
        }

        Console.WriteLine("Odd Function : " + n);

        Even(n - 1);
    }
}