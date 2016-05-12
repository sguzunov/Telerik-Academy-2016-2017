// Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements. Print that sum.

using System;

class MaximalSum
{
    static void Main()
    {
        string[] dimensionsSize = Console.ReadLine().Split(' ');

        int height = int.Parse(dimensionsSize[0]);
        int width = int.Parse(dimensionsSize[1]);
        int[,] matrix = ReadMatrixValues(height, width);

        int platformHeight = 3;
        int platformWidth = 3;
        long maxSum = FindPlatformMaxSum(platformHeight, platformWidth, matrix);
        Console.WriteLine(maxSum);
    }

    private static long FindPlatformMaxSum(int platformHeight, int platformWidth, int[,] matrix)
    {
        long maxSum = long.MinValue;
        for (int row = 0; row < matrix.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                long sum = 0L;
                for (int i = row; i < row + platformHeight; i++)
                {
                    for (int j = col; j < col + platformWidth; j++)
                    {
                        sum += matrix[i, j];
                    }
                }

                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }
        }

        return maxSum;
    }

    private static int[,] ReadMatrixValues(int height, int width)
    {
        int[,] matrix = new int[height, width];
        for (int i = 0; i < height; i++)
        {
            string[] values = Console.ReadLine().Split(' ');
            for (int j = 0; j < width; j++)
            {
                matrix[i, j] = int.Parse(values[j]);
            }
        }

        return matrix;
    }
}
