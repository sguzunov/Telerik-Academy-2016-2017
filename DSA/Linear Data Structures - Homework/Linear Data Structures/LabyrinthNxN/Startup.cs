// We are given a labyrinth of size N x N.
// Some of its cells are empty(0) and some are full(x).
// We can move from an empty cell to another empty cell if they share common wall.
// Given a starting position (*) calculate and fill in the array the minimal distance from this position to any other cell in the array. Use "u" for all unreachable cells

using System;
using System.Collections.Generic;

namespace LabyrinthNxN
{
    public class Startup
    {
        public static void Main()
        {
            var matrix = new string[,]
            {
                {"0","0","0","x","0","x" },
                {"0","x","0","x","0","x" },
                {"0","*","x","0","x","0" },
                {"0","x","0","0","0","0" },
                {"0","0","0","x","x","0" },
                {"0","0","0","x","0","x" }
            };

            var startPosition = new Position() { X = 1, Y = 2 };
            AddMinimalDistanceFromPosition(startPosition, matrix);
            MarkUnreachable(matrix);

            Print(matrix);
        }

        private static void MarkUnreachable(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == "0")
                    {
                        matrix[i, j] = "u";
                    }
                }
            }
        }

        private static void Print(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void AddMinimalDistanceFromPosition(Position start, string[,] matrix)
        {
            var positions = new Queue<Position>();
            positions.Enqueue(start);
            AddNeighbours(start, matrix);
            while (positions.Count > 0)
            {
                var position = positions.Dequeue();
                foreach (var neighbour in position.Neighbours)
                {
                    int distance = 1;
                    int.TryParse(matrix[position.Y, position.X], out distance);
                    distance++;
                    matrix[neighbour.Y, neighbour.X] = distance.ToString();

                    AddNeighbours(neighbour, matrix);
                    positions.Enqueue(neighbour);
                }
            }
        }

        private static void AddNeighbours(Position position, string[,] matrix)
        {
            var deltasX = new int[] { 0, 1, 0, -1 };
            var deltasY = new int[] { -1, 0, 1, 0 };

            for (int i = 0; i < deltasX.Length; i++)
            {
                int nextY = position.Y + deltasY[i];
                int nextX = position.X + deltasX[i];

                bool inRange = (0 <= nextX && nextX < matrix.GetLength(1)) &&
                    (0 <= nextY && nextY < matrix.GetLength(0));
                if (inRange && matrix[nextY, nextX] == "0")
                {
                    position.Neighbours.Add(new Position { X = nextX, Y = nextY });
                }
            }
        }
    }
}
