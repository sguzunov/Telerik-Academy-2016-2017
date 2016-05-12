// Write a program that finds the largest area of equal neighbour elements in a rectangular matrix and prints its size.

using System;

public class LargestAreaInMatrix
{
    static void Main()
    {
        string[] dimensionsAsString = Console.ReadLine().Split(' ');

        int rows = int.Parse(dimensionsAsString[0]);
        int cols = int.Parse(dimensionsAsString[1]);
        int[,] matrix = ReadMatrix(rows, cols);
        bool[,] visited = new bool[rows, cols];
        int maxAreaSize = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (!visited[row, col])
                {
                    int areaSize = FindLargestArea(row, col, 0, matrix, visited);
                    if (areaSize > maxAreaSize)
                    {
                        maxAreaSize = areaSize;
                    }
                }
            }
        }

        Console.WriteLine(maxAreaSize);
    }

    private static int FindLargestArea(int row, int col, int areaSize, int[,] matrix, bool[,] visited)
    {
        visited[row, col] = true;
        areaSize++;
        if ((col - 1) >= 0 && !visited[row, col - 1] && (matrix[row, col - 1] == matrix[row, col]))
        {
            areaSize = FindLargestArea(row, col - 1, areaSize, matrix, visited);
        }

        if ((col + 1) < matrix.GetLength(1) && !visited[row, col + 1] && (matrix[row, col + 1] == matrix[row, col]))
        {
            areaSize = FindLargestArea(row, col + 1, areaSize, matrix, visited);
        }

        if ((row - 1) >= 0 && !visited[row - 1, col] && (matrix[row - 1, col] == matrix[row, col]))
        {
            areaSize = FindLargestArea(row - 1, col, areaSize, matrix, visited);
        }

        if ((row + 1) < matrix.GetLength(0) && !visited[row + 1, col] && (matrix[row + 1, col] == matrix[row, col]))
        {
            areaSize = FindLargestArea(row + 1, col, areaSize, matrix, visited);
        }

        return areaSize;
    }

    private static int[,] ReadMatrix(int rows, int cols)
    {
        int[,] matrix = new int[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            string[] rowValues = Console.ReadLine().Split(' ');
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = int.Parse(rowValues[col]);
            }
        }

        return matrix;
    }
}
