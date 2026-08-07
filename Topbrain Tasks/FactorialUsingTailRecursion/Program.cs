using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        Console.Write($"Factorial : {Factorial(number)}");

    }

    static int Factorial(int n, int accumulator = 1)
    {
        if (n <= 1)
        {
            return accumulator;
        }

        return Factorial(n-1, accumulator*n);
    }
}