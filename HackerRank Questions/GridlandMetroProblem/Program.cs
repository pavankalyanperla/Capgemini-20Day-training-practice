using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Enter number of rows (n): ");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter number of columns (m): ");
        int m = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter number of tracks (k): ");
        int k = Convert.ToInt32(Console.ReadLine());

        List<List<int>> tracks = new List<List<int>>();

        Console.WriteLine("\nEnter each track as: row startColumn endColumn");

        for (int i = 0; i < k; i++)
        {
            string[] input = Console.ReadLine().Split();

            tracks.Add(new List<int>
            {
                Convert.ToInt32(input[0]),
                Convert.ToInt32(input[1]),
                Convert.ToInt32(input[2])
            });
        }

        long result = GridlandMetro(n, m, tracks);

        Console.WriteLine("\nNumber of cells available for lampposts = " + result);
    }

    static long GridlandMetro(int n, int m, List<List<int>> tracks)
    {
        // Store tracks row-wise
        Dictionary<int, List<(int start, int end)>> rows =
            new Dictionary<int, List<(int, int)>>();

        foreach (var track in tracks)
        {
            int row = track[0];
            int start = track[1];
            int end = track[2];

            if (!rows.ContainsKey(row))
            {
                rows[row] = new List<(int, int)>();
            }

            rows[row].Add((start, end));
        }

        long occupiedCells = 0;

        foreach (var row in rows)
        {
            // Sort tracks by starting column
            var intervals = row.Value.OrderBy(x => x.start).ToList();

            int currentStart = intervals[0].start;
            int currentEnd = intervals[0].end;

            for (int i = 1; i < intervals.Count; i++)
            {
                if (intervals[i].start <= currentEnd)
                {
                    // Merge overlapping tracks
                    currentEnd = Math.Max(currentEnd, intervals[i].end);
                }
                else
                {
                    occupiedCells += currentEnd - currentStart + 1;

                    currentStart = intervals[i].start;
                    currentEnd = intervals[i].end;
                }
            }

            // Count the last merged interval
            occupiedCells += currentEnd - currentStart + 1;
        }

        long totalCells = (long)n * m;

        return totalCells - occupiedCells;
    }
}