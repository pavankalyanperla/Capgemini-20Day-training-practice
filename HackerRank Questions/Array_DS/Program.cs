using System;
using System.Collections.Generic;

class Result
{
    public static List<int> ReverseArray(List<int> a)
    {
        List<int> result = new List<int>();

        for (int i = a.Count - 1; i >= 0; i--)
        {
            result.Add(a[i]);
        }

        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());

        List<int> arr = new List<int>();

        Console.WriteLine("Enter the elements:");

        for (int i = 0; i < n; i++)
        {
            arr.Add(Convert.ToInt32(Console.ReadLine()));
        }

        List<int> reversed = Result.ReverseArray(arr);

        Console.WriteLine("\nReversed Array:");

        foreach (int num in reversed)
        {
            Console.Write(num + " ");
        }
    }
}