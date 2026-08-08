using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the numbers:");

        string[] input = Console.ReadLine().Split(' ');

        long sum = 0;

        for (int i = 0; i < n; i++)
        {
            long number = Convert.ToInt64(input[i]);

            sum += number;
        }

        Console.WriteLine("Sum = " + sum);
    }
}