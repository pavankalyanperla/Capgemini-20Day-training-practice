using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Enter number of test cases: ");
        int t = Convert.ToInt32(Console.ReadLine());

        for (int test = 0; test < t; test++)
        {
            Console.Write("\nEnter money: ");
            int m = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter number of flavors: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter flavor prices:");
            string[] input = Console.ReadLine().Split(' ');

            List<int> prices = new List<int>();

            for (int i = 0; i < n; i++)
            {
                prices.Add(Convert.ToInt32(input[i]));
            }

            List<int> result = IcecreamParlor(m, prices);

            Console.WriteLine("Flavor indices: " +
                              result[0] + " " + result[1]);
        }
    }

    static List<int> IcecreamParlor(int m, List<int> prices)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < prices.Count; i++)
        {
            int cost = prices[i];

            int remaining = m - cost;

            // Check whether the required price
            // was already seen
            if (map.ContainsKey(remaining))
            {
                return new List<int>
                {
                    map[remaining] + 1,
                    i + 1
                };
            }

            // Store price and its index
            if (!map.ContainsKey(cost))
            {
                map.Add(cost, i);
            }
        }

        return new List<int>();
    }
}