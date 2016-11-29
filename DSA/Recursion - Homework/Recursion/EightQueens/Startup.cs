using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueens
{
    public class Startup
    {
        static int total;
        public static void Main()
        {
            /*
            x . . . . . . . . . . . .
            . . x . . . . . . . . . .
            . . . . x . . . . . . . .
            . x . . . . . . . . . . .
            . . . . . . . . x . . . .
            . . . . . . . . . . . x .
            . . . . . . . . . x . . .
            . . . . . . . . . . . . x
            . . . x . . . . . . . . .
            . . . . . x . . . . . . .
            . . . . . . . x . . . . .
            . . . . . . . . . . x . .
            . . . . . . x . . . . . .
            */

            int n = 8;
            NextQueen(0, n, new bool[n], new int[n], new bool[2 * n], new bool[2 * n]);
            Console.WriteLine(total);
        }

        private static void NextQueen(int i, int n, bool[] cols, int[] queens, bool[] leftDiagonals, bool[] rightDiagonals)
        {
            if (i == n)
            {
                total++;
                //PrintBoard(queens);
                return;
            }

            for (int j = 0; j < n; j++)
            {
                int left = n + i - j;
                int right = i + j;
                if (!cols[j] && !leftDiagonals[left] && !rightDiagonals[right])
                {
                    cols[j] = true;
                    leftDiagonals[left] = true;
                    rightDiagonals[right] = true;
                    queens[i] = j;
                    NextQueen(i + 1, n, cols, queens, leftDiagonals, rightDiagonals);
                    cols[j] = false;
                    leftDiagonals[left] = false;
                    rightDiagonals[right] = false;
                }
            }
        }

        private static void PrintBoard(int[] queens)
        {
            for (int i = 0; i < queens.Length; i++)
            {
                for (int j = 0; j < queens.Length; j++)
                {
                    if (queens[i] == j)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write(". ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
