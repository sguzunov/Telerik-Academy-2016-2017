using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExistingPathBetweenTwoCells
{
    public class Startup
    {
        public static void Main()
        {
            var falseMatrix = new char[,]
            {
                {'s', ' ', ' ', ' ' },
                {' ', '#', '#', ' ' },
                {' ', '#', '#', ' ' },
                {' ', '#', 'e', '#' },
                {' ', ' ', '#', ' ' },
            };

            var trueMatrix = new char[,]
            {
                {'s', ' ', ' ', ' ' },
                {' ', '#', '#', ' ' },
                {' ', '#', '#', ' ' },
                {' ', '#', 'e', ' ' },
                {' ', ' ', ' ', ' ' },
            };

            Console.WriteLine(FindPath(0, 0, trueMatrix));
            Console.WriteLine(FindPath(0, 0, falseMatrix));
        }

        private static bool FindPath(int row, int col, char[,] matrix)
        {
            if (matrix[row, col] == 'e')
            {
                return true;
            }

            var deltaX = new int[] { 0, 1, 0, -1 };
            var deltaY = new int[] { -1, 0, 1, 0 };
            matrix[row, col] = '#';
            for (int i = 0; i < deltaX.Length; i++)
            {
                var newRow = row + deltaY[i];
                var newCol = col + deltaX[i];
                if (newRow >= 0 && newRow < matrix.GetLength(0) &&
                    newCol >= 0 && newCol < matrix.GetLength(1) &&
                    (matrix[newRow, newCol] == ' ' || matrix[newRow, newCol] == 'e'))
                {
                    if (FindPath(newRow, newCol, matrix))
                    {
                        return true;
                    }
                }
            }

            matrix[row, col] = ' ';

            return false;
        }
    }
}
