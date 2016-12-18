using System;

namespace KnightsTour
{
    public class Startup
    {
        public static void Main()
        {
            Console.Write("Enter board size: ");
            int n = int.Parse(Console.ReadLine());

            GetNextMove(new int[n, n], 0, 0, 1);
            Console.WriteLine("No solution!");
        }

        private static void PrintBoard(int[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write("{0}", board[i, j].ToString().PadLeft(4));
                }

                Console.WriteLine();
            }
        }

        private static void GetNextMove(int[,] board, int x, int y, int step)
        {
            board[x, y] = step;

            if (step == board.GetLength(0) * board.GetLength(1))
            {
                PrintBoard(board);
                Environment.Exit(0);
            }

            var deltaX = new[] { 1, 1, -1, -1, 2, -2, 2, -2 };
            var deltaY = new[] { 2, -2, 2, -2, 1, 1, -1, -1 };
            for (int i = 0; i < deltaX.Length; i++)
            {
                var nextX = x + deltaX[i];
                var nextY = y + deltaY[i];
                if (0 <= nextX && nextX < board.GetLength(0) &&
                    0 <= nextY && nextY < board.GetLength(1) &&
                    board[nextX, nextY] == 0)
                {
                    GetNextMove(board, nextX, nextY, step + 1);
                }
            }

            board[x, y] = 0;
        }
    }
}
