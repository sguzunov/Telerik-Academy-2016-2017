using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectedArea
{
    public class Startup
    {
        public static void Main()
        {
            var matrix = new char[,]
            {
                {' ', ' ', '#', ' ' },
                {' ', '#', '#', ' ' },
                {' ', '#', '#', ' ' },
                {' ', '#', ' ', '#' },
                {' ', ' ', ' ', ' ' },
            };

            int maxArea = -1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == ' ')
                    {
                        int area = CountArea(row, col, matrix);
                        if (maxArea < area)
                        {
                            maxArea = area;
                        }
                    }
                }
            }

            Console.WriteLine(maxArea);
        }

        private static int CountArea(int row, int col, char[,] matrix)
        {
            var deltaX = new int[] { 0, 1, 0, -1 };
            var deltaY = new int[] { -1, 0, 1, 0 };
            matrix[row, col] = '#';
            int count = 1;
            for (int i = 0; i < deltaX.Length; i++)
            {
                var newRow = row + deltaY[i];
                var newCol = col + deltaX[i];

                if (newRow >= 0 && newRow < matrix.GetLength(0) &&
                    newCol >= 0 && newCol < matrix.GetLength(1) &&
                    (matrix[newRow, newCol] == ' ' || matrix[newRow, newCol] == 'e'))
                {
                    count += CountArea(newRow, newCol, matrix);
                }
            }

            return count;
        }
    }
}
