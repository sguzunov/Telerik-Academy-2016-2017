/* Write a program that reads from the console a positive integer number N (1 ≤ N ≤ 20) and prints a matrix holding the numbers from 1 to N*N in the form of square spiral like in the examples below. */

using System;

class SpiralMatrix
{
    private const int startRow = 0;
    private const int startCol = 0;

    private static string up = "up";
    private static string down = "down";
    private static string right = "right";
    private static string left = "left";

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[,] spiralMatrix = new int[n, n];
        //FillMatrixResursively(1, startRow, startCol, spiralMatrix, right);
        FillMatrixIteratively(startRow, startCol, spiralMatrix, right, true, 1);
        PrintMatrix(spiralMatrix);
    }

    private static void FillMatrixIteratively(int row, int col, int[,] matrix, string direction, bool canGo = true, int number = 1)
    {
        while (true)
        {
            matrix[row, col] = number;
            if (direction == right)
            {
                int nextCol = col + 1;
                int nextRow = row + 1;
                if ((nextCol) < matrix.GetLength(0) && matrix[row, nextCol] == 0)
                {
                    col++;
                }
                else if ((nextRow) < matrix.GetLength(1) && matrix[nextRow, col] == 0)
                {
                    row++;
                    direction = down;
                }
                else
                {
                    canGo = false;
                }
            }
            else if (direction == down)
            {
                int nextRow = row + 1;
                int nextCol = col - 1;
                if ((nextRow) < matrix.GetLength(1) && matrix[nextRow, col] == 0)
                {
                    row++;
                }
                else if ((nextCol) >= 0 && matrix[row, nextCol] == 0)
                {
                    col--;
                    direction = left;
                }
                else
                {
                    canGo = false;
                }
            }
            else if (direction == left)
            {
                int nextRow = row - 1;
                int nextCol = col - 1;
                if ((nextCol) >= 0 && matrix[row, nextCol] == 0)
                {
                    col--;
                }
                else if ((nextRow) >= 0 && matrix[nextRow, col] == 0)
                {
                    row--;
                    direction = up;
                }
                else
                {
                    canGo = false;
                }
            }
            else
            {
                int nextRow = row - 1;
                int nextCol = col + 1;
                if ((nextRow) >= 0 && matrix[nextRow, col] == 0)
                {
                    row--;
                }
                else if ((nextCol) < matrix.GetLength(0) && matrix[row, nextCol] == 0)
                {
                    col++;
                    direction = right;
                }
                else
                {
                    canGo = false;
                }
            }

            number++;
            if (!canGo)
            {
                break;
            }
        }
    }

    //private static void FillMatrixResursively(int number, int row, int col, int[,] matrix, string direction, bool canGo = true)
    //{
    //    matrix[row, col] = number;
    //    if (direction == right)
    //    {
    //        int nextCol = col + 1;
    //        int nextRow = row + 1;
    //        if ((nextCol) < matrix.GetLength(0) && matrix[row, nextCol] == 0)
    //        {
    //            col++;
    //        }
    //        else if ((nextRow) < matrix.GetLength(1) && matrix[nextRow, col] == 0)
    //        {
    //            row++;
    //            direction = down;
    //        }
    //        else
    //        {
    //            canGo = false;
    //        }
    //    }
    //    else if (direction == down)
    //    {
    //        int nextRow = row + 1;
    //        int nextCol = col - 1;
    //        if ((nextRow) < matrix.GetLength(1) && matrix[nextRow, col] == 0)
    //        {
    //            row++;
    //        }
    //        else if ((nextCol) >= 0 && matrix[row, nextCol] == 0)
    //        {
    //            col--;
    //            direction = left;
    //        }
    //        else
    //        {
    //            canGo = false;
    //        }
    //    }
    //    else if (direction == left)
    //    {
    //        int nextRow = row - 1;
    //        int nextCol = col - 1;
    //        if ((nextCol) >= 0 && matrix[row, nextCol] == 0)
    //        {
    //            col--;
    //        }
    //        else if ((nextRow) >= 0 && matrix[nextRow, col] == 0)
    //        {
    //            row--;
    //            direction = up;
    //        }
    //        else
    //        {
    //            canGo = false;
    //        }
    //    }
    //    else
    //    {
    //        int nextRow = row - 1;
    //        int nextCol = col + 1;
    //        if ((nextRow) >= 0 && matrix[nextRow, col] == 0)
    //        {
    //            row--;
    //        }
    //        else if ((nextCol) < matrix.GetLength(0) && matrix[row, nextCol] == 0)
    //        {
    //            col++;
    //            direction = right;
    //        }
    //        else
    //        {
    //            canGo = false;
    //        }
    //    }

    //    if (canGo)
    //    {
    //        FillMatrixResursively(number + 1, row, col, matrix, direction, canGo);
    //    }
    //}

    private static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }

            Console.WriteLine();
        }
    }
}
