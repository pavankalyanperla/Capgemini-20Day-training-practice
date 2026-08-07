using System;

class Program
{
    static int CountPaths(int rows, int cols)
    {
        // Only one path if there is only one row or one column
        if (rows == 1 || cols == 1)
        {
            return 1;
        }

        // Move Down + Move Right
        return CountPaths(rows - 1, cols) + CountPaths(rows, cols - 1);
    }

    static void Main()
    {
        Console.Write("Enter rows: ");
        int rows = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter columns: ");
        int cols = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Total Paths = " + CountPaths(rows, cols));
    }
}