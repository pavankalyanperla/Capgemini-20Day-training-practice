using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Enter number of sequences (n): ");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter number of queries (q): ");
        int q = Convert.ToInt32(Console.ReadLine());

        List<List<int>> seqList = new List<List<int>>();

        // Create n empty sequences
        for (int i = 0; i < n; i++)
        {
            seqList.Add(new List<int>());
        }

        int lastAnswer = 0;

        Console.WriteLine("\nEnter queries (type x y):");

        for (int i = 0; i < q; i++)
        {
            string[] input = Console.ReadLine().Split(' ');

            int type = Convert.ToInt32(input[0]);
            int x = Convert.ToInt32(input[1]);
            int y = Convert.ToInt32(input[2]);

            int idx = (x ^ lastAnswer) % n;

            if (type == 1)
            {
                seqList[idx].Add(y);
            }
            else if (type == 2)
            {
                lastAnswer = seqList[idx][y % seqList[idx].Count];
                Console.WriteLine("Last Answer = " + lastAnswer);
            }
        }
    }
}