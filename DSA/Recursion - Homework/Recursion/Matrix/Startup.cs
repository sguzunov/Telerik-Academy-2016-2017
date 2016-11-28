using System;
using System.Collections.Generic;

namespace Matrix
{
    public class Startup
    {
        public static void Main()
        {
            var matrix = new char[,]
            {
                {'s', ' ', ' ', ' ' },
                {' ', '#', '#', ' ' },
                {' ', '#', '#', ' ' },
                {' ', '#', 'e', ' ' },
                {' ', ' ', ' ', ' ' },
            };

            FindPath(0, 0, matrix, 'S', new List<char>());
        }

        private static void FindPath(int row, int col, char[,] matrix, char dir, List<char> path)
        {
            if (matrix[row, col] == 'e')
            {
                Console.WriteLine(string.Join("", path));
                return;
            }

            var deltaX = new int[] { 0, 1, 0, -1 };
            var deltaY = new int[] { -1, 0, 1, 0 };

            matrix[row, col] = dir;
            for (int i = 0; i < deltaX.Length; i++)
            {
                var newRow = row + deltaY[i];
                var newCol = col + deltaX[i];
                if (newRow >= 0 && newRow < matrix.GetLength(0) &&
                    newCol >= 0 && newCol < matrix.GetLength(1) &&
                    (matrix[newRow, newCol] == ' ' || matrix[newRow, newCol] == 'e'))
                {
                    var newDir = 'L';
                    if (i == 0)
                    {
                        newDir = 'U';
                    }
                    else if (i == 1)
                    {
                        newDir = 'R';
                    }
                    else if (i == 2)
                    {
                        newDir = 'D';
                    }

                    path.Add(newDir);
                    FindPath(newRow, newCol, matrix, newDir, path);
                    path.RemoveAt(path.Count - 1);
                }
            }

            matrix[row, col] = ' ';
        }
    }
}
