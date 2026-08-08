using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter number of rows: ");
        int H = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter number of columns: ");
        int W = Convert.ToInt32(Console.ReadLine());

        int[,] A = new int[H, W];

        Console.WriteLine("Enter the grid:");

        for (int i = 0; i < H; i++)
        {
            string[] input = Console.ReadLine().Split(' ');

            for (int j = 0; j < W; j++)
            {
                A[i, j] = Convert.ToInt32(input[j]);
            }
        }

        int result = SurfaceArea(A, H, W);

        Console.WriteLine("Total Surface Area = " + result);
    }

    static int SurfaceArea(int[,] A, int H, int W)
    {
        int area = 0;

        for (int i = 0; i < H; i++)
        {
            for (int j = 0; j < W; j++)
            {
                int height = A[i, j];

                if (height == 0)
                    continue;

                // Top and Bottom
                area += 2;

                // Up
                if (i == 0)
                {
                    area += height;
                }
                else
                {
                    area += Math.Max(
                        0,
                        height - A[i - 1, j]
                    );
                }

                // Down
                if (i == H - 1)
                {
                    area += height;
                }
                else
                {
                    area += Math.Max(
                        0,
                        height - A[i + 1, j]
                    );
                }

                // Left
                if (j == 0)
                {
                    area += height;
                }
                else
                {
                    area += Math.Max(
                        0,
                        height - A[i, j - 1]
                    );
                }

                // Right
                if (j == W - 1)
                {
                    area += height;
                }
                else
                {
                    area += Math.Max(
                        0,
                        height - A[i, j + 1]
                    );
                }
            }
        }

        return area;
    }
}