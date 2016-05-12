// 

using System;

class SequenceInMatrix
{
    static void Main()
    {
        string[] dimensionsAsString = Console.ReadLine().Split(' ');

        int rows = int.Parse(dimensionsAsString[0]);
        int cols = int.Parse(dimensionsAsString[1]);
        string[,] matrix = ReadMatrix(rows, cols);

        int horizontalMaxSequence = FindHorizontalMaxSequence(matrix);
        int verticalMaxSequence = FindVerticalMaxSequence(matrix);

        int leftRightDiagonalsMaxSequence = FindLeftRightDiagonalsMaxSequence(matrix);
        int rightLeftDiagonalsMaxSequence = FindRightLeftDiagonalsMaxSequence(matrix);

        int horizontalVerticalMaxSequence = 0;
        if (horizontalMaxSequence >= verticalMaxSequence)
        {
            horizontalVerticalMaxSequence = horizontalMaxSequence;
        }
        else
        {
            horizontalVerticalMaxSequence = verticalMaxSequence;
        }

        int diagonalsMaxSequence = 0;
        if (leftRightDiagonalsMaxSequence >= rightLeftDiagonalsMaxSequence)
        {
            diagonalsMaxSequence = leftRightDiagonalsMaxSequence;
        }
        else
        {
            diagonalsMaxSequence = rightLeftDiagonalsMaxSequence;
        }

        if (horizontalVerticalMaxSequence > diagonalsMaxSequence)
        {
            Console.WriteLine(horizontalVerticalMaxSequence);
        }
        else
        {
            Console.WriteLine(diagonalsMaxSequence);
        }
    }

    private static int FindRightLeftDiagonalsMaxSequence(string[,] matrix)
    {
        int maxSequence = 1;
        int currentSequence = 1;
        int col = 1;
        int row = 1;
        while (col < matrix.GetLength(1))
        {
            currentSequence = 1;
            int i = col - 1;
            row = 1;
            while (i >= 0 && row < matrix.GetLength(0))
            {
                if (matrix[row, i] == matrix[row - 1, i + 1])
                {
                    currentSequence++;
                }
                else
                {
                    currentSequence = 1;
                }

                if (currentSequence > maxSequence)
                {
                    maxSequence = currentSequence;
                }

                i--;
                row++;
            }

            col++;
        }

        row = 1;
        while (row < matrix.GetLength(0) - 1)
        {
            currentSequence = 1;
            col = matrix.GetLength(1) - 2;
            int i = row + 1;
            while (i < matrix.GetLength(0) && col >= 0)
            {
                if (matrix[i, col] == matrix[i - 1, col + 1])
                {
                    currentSequence++;
                }
                else
                {
                    currentSequence = 1;
                }

                if (currentSequence > maxSequence)
                {
                    maxSequence = currentSequence;
                }

                i++;
                col--;
            }

            row++;
        }

        return maxSequence;
    }

    private static int FindLeftRightDiagonalsMaxSequence(string[,] matrix)
    {
        int maxSequence = 1;
        int currentSequence = 1;
        int row = matrix.GetLength(0) - 2;
        int col = 1;
        while (row >= 0)
        {
            currentSequence = 1;
            int i = row + 1;
            col = 1;
            while (i < matrix.GetLength(0) && col < matrix.GetLength(1))
            {
                if (matrix[i, col] == matrix[i - 1, col - 1])
                {
                    currentSequence++;
                }
                else
                {
                    currentSequence = 1;
                }

                if (currentSequence > maxSequence)
                {
                    maxSequence = currentSequence;
                }

                col++;
                i++;
            }

            row--;
        }

        col = 1;
        while (col < matrix.GetLength(1))
        {
            currentSequence = 1;
            int i = col + 1;
            row = 1;
            while (i < matrix.GetLength(1) && row < matrix.GetLength(0))
            {
                if (matrix[row, i] == matrix[row - 1, i - 1])
                {
                    currentSequence++;
                }
                else
                {
                    currentSequence = 1;
                }

                if (currentSequence > maxSequence)
                {
                    maxSequence = currentSequence;
                }

                i++;
                row++;
            }

            col++;
        }

        return maxSequence;
    }

    private static int FindVerticalMaxSequence(string[,] matrix)
    {
        int maxSequence = 0;
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            int currentSequnece = 1;
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, col] == matrix[row - 1, col])
                {
                    currentSequnece++;
                }
                else
                {
                    currentSequnece = 1;
                }

                if (currentSequnece > maxSequence)
                {
                    maxSequence = currentSequnece;
                }
            }
        }

        return maxSequence;
    }

    private static int FindHorizontalMaxSequence(string[,] matrix)
    {
        int maxSequence = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            int currentSequnece = 1;
            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == matrix[row, col - 1])
                {
                    currentSequnece++;
                }
                else
                {
                    currentSequnece = 1;
                }

                if (currentSequnece > maxSequence)
                {
                    maxSequence = currentSequnece;
                }
            }
        }

        return maxSequence;
    }

    private static string[,] ReadMatrix(int rows, int cols)
    {
        string[,] matrix = new string[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            string[] rowValues = Console.ReadLine().Split(' ');
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = rowValues[col];
            }
        }

        return matrix;
    }
}
