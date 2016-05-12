// Write a program that fills and prints a matrix of size (n, n) as shown below.

using System;
using System.Text;

class FillTheMatrix
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char matrixType = char.Parse(Console.ReadLine());

        int[,] generatedMatrix = GenerateMatrixOfType(matrixType, n);
        PrintMatrx(generatedMatrix);
    }

    private static int[,] GenerateMatrixOfType(char matrixType, int size)
    {
        int[,] matrix = new int[size, size];
        switch (matrixType)
        {
            case 'a':
                matrix = GetMatrixOfTypeA(size);
                break;
            case 'b':
                matrix = GetMatrixOfTypeB(size);
                break;
            case 'c':
                matrix = GetMatrixOfTypeC(size);
                break;
            case 'd':
                matrix = GetMatrixOfTypeD(size);
                break;
        }

        return matrix;
    }

    private static int[,] GetMatrixOfTypeA(int n)
    {
        int value = 1;
        int[,] matrix = new int[n, n];
        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                matrix[row, col] = value;
                value++;
            }
        }

        return matrix;
    }

    private static int[,] GetMatrixOfTypeB(int n)
    {
        int value = 0;
        int[,] matrix = new int[n, n];
        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                if (col % 2 == 0)
                {
                    value = ((col + 1) * n - (n - row)) + 1;
                }
                else
                {
                    value = (col + 1) * n - row;
                }

                matrix[row, col] = value;
            }
        }

        return matrix;
    }

    private static int[,] GetMatrixOfTypeC(int n)
    {
        int value = 1;
        int[,] matrix = new int[n, n];

        for (int i = n - 1; i >= 0; i--)
        {
            int row = i;
            int col = 0;
            while (row < n)
            {
                matrix[row, col] = value;
                value++;
                row++;
                col++;
            }
        }

        for (int i = 1; i < n; i++)
        {
            int row = 0;
            int col = i;
            while (col < n)
            {
                matrix[row, col] = value;
                value++;
                row++;
                col++;
            }
        }

        return matrix;
    }

    private static int[,] GetMatrixOfTypeD(int n)
    {
        int value = 1;
        int[,] matrix = new int[n, n];
        bool canGo = true;
        string directionRight = "right";
        string directionLeft = "left";
        string directionUp = "up";
        string directionDown = "down";
        string direction = directionDown;
        int row = 0;
        int col = 0;
        while (true)
        {
            matrix[row, col] = value;
            value++;
            if (direction == directionDown)
            {
                if ((row + 1) < n && matrix[row + 1, col] == 0)
                {
                    row++;
                }
                else if ((col + 1) < n && matrix[row, col + 1] == 0)
                {
                    direction = directionRight;
                    col++;
                }
                else
                {
                    canGo = false;
                }
            }
            else if (direction == directionRight)
            {
                if ((col + 1) < n && matrix[row, col + 1] == 0)
                {
                    col++;
                }
                else if ((row - 1) >= 0 && matrix[row - 1, col] == 0)
                {
                    direction = directionUp;
                    row--;
                }
                else
                {
                    canGo = false;
                }
            }
            else if (direction == directionUp)
            {
                if ((row - 1) >= 0 && matrix[row - 1, col] == 0)
                {
                    row--;
                }
                else if ((col - 1) >= 0 && matrix[row, col - 1] == 0)
                {
                    direction = directionLeft;
                    col--;
                }
                else
                {
                    canGo = false;
                }
            }
            else
            {
                if ((col - 1) >= 0 && matrix[row, col - 1] == 0)
                {
                    col--;
                }
                else if ((row + 1) < n && matrix[row + 1, col] == 0)
                {
                    direction = directionDown;
                    row++;
                }
                else
                {
                    canGo = false;
                }
            }

            if (!canGo)
            {
                break;
            }
        }

        return matrix;
    }

    private static void PrintMatrx(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            StringBuilder builder = new StringBuilder();
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
                if (col < matrix.GetLength(1) - 1)
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine();
        }
    }
}
