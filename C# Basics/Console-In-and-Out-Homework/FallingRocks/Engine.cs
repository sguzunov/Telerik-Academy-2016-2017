namespace FallingRocks
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Threading;

    public class Engine
    {
        // Console constants.
        private const int ConsoleWidth = 80;

        // Player constants.
        private const string PlayerSign = "(0)";
        private const ConsoleColor PlayerColor = ConsoleColor.Blue;

        // Player's movement steps.
        private const sbyte LeftStep = -1;
        private const sbyte RightStep = 1;

        private const int StoneStartPositionY = 0;
        private const string MoneySign = "$";
        private const ConsoleColor EnemyColor = ConsoleColor.Red;
        private const ConsoleColor MoneyColor = ConsoleColor.Yellow;

        private static readonly int PlayerStartPositionX = Console.WindowWidth / 2;
        private static readonly int PlayerStartPositionY = Console.WindowHeight - 1;

        private static string[] stoneSigns = new string[] { "^", "@", "*", "&", "+", "$", "%", "#", "!", ".", ";", "-" };
        private static int playerPoints;
        private static bool isAlive = true;

        public static void Main()
        {
            SetConsoleOptions();
            var player = CreatePlayer();
            List<GameObject> stones = new List<GameObject>();
            while (isAlive)
            {
                GameObject stone = CreateStone();
                stones.Add(stone);

                CheckForCollision(player, stones);
                RemoveFallenStones(stones);

                RenderGameObject(player);
                RenderStones(stones);

                if (Console.KeyAvailable)
                {
                    var pressedKey = Console.ReadKey();
                    UpdatePlayerPosition(player, pressedKey);
                }

                UpdateStonesPosition(stones);
                Thread.Sleep(150);
                Console.Clear();
            }

            Console.WriteLine("LOOOSERRR :D:D:D");
            Console.WriteLine("Your points: {0}", playerPoints);
        }

        // TODO: Precision collision.
        private static void CheckForCollision(GameObject player, List<GameObject> stones)
        {
            for (int i = 0; i < stones.Count; i++)
            {
                var collisionCandidate = stones[i];
                bool hasCollision = (collisionCandidate.PositionOnConcole.y == Console.WindowHeight - 2) &&
                    (collisionCandidate.PositionOnConcole.x >= player.PositionOnConcole.x && collisionCandidate.PositionOnConcole.x < player.PositionOnConcole.x + player.Sign.Length);
                if (hasCollision)
                {
                    if (collisionCandidate.Sign == MoneySign)
                    {
                        playerPoints++;
                    }
                    else
                    {
                        isAlive = false;
                    }
                }
            }
        }

        private static void RemoveFallenStones(List<GameObject> stones)
        {
            for (int i = 0; i < stones.Count; i++)
            {
                if (stones[i].PositionOnConcole.y == Console.WindowHeight)
                {
                    stones.RemoveAt(i);
                }
            }
        }

        private static void UpdatePlayerPosition(GameObject player, ConsoleKeyInfo pressedKey)
        {
            switch (pressedKey.Key)
            {
                case ConsoleKey.LeftArrow:
                    {
                        if (player.PositionOnConcole.x > 0)
                        {
                            player.PositionOnConcole.x--;
                        }

                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        if (player.PositionOnConcole.x + player.Sign.Length < ConsoleWidth - 1)
                        {
                            player.PositionOnConcole.x++;
                        }
                        break;
                    }
            }
        }

        private static void UpdateStonesPosition(List<GameObject> stones)
        {
            for (int i = 0; i < stones.Count; i++)
            {
                stones[i].PositionOnConcole.y++;
            }
        }

        private static GameObject CreatePlayer()
        {
            Position playerStarPosition = GetNewPosition(PlayerStartPositionX - (PlayerSign.Length / 2), PlayerStartPositionY);
            var player = new GameObject(PlayerSign, playerStarPosition, PlayerColor);
            return player;
        }

        private static Position GetNewPosition(int x, int y)
        {
            Position position = new Position(x, y);
            return position;
        }

        private static GameObject CreateStone()
        {
            int signIndex = GetRandomNumber(0, stoneSigns.Length - 1);
            string randomStoneSign = stoneSigns[signIndex];
            ConsoleColor color = EnemyColor;
            if (randomStoneSign == MoneySign)
            {
                color = MoneyColor;
            }

            int stoneStartPositionX = GetRandomNumber(0, Console.WindowWidth - 1);
            Position stonePosition = GetNewPosition(stoneStartPositionX, StoneStartPositionY);
            GameObject stone = new GameObject(randomStoneSign, stonePosition, color);
            return stone;
        }

        private static void RenderStones(List<GameObject> stones)
        {
            for (int i = 0; i < stones.Count; i++)
            {
                GameObject stone = stones[i];
                RenderGameObject(stone);
            }
        }

        private static void RenderGameObject(GameObject gameObject)
        {
            Console.SetCursorPosition(gameObject.PositionOnConcole.x, gameObject.PositionOnConcole.y);
            Console.ForegroundColor = gameObject.Color;
            Console.Write(gameObject.Sign);
        }

        private static void SetConsoleOptions()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.WindowWidth = ConsoleWidth;
            Console.CursorVisible = false;

            // Removes scrollbar.
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }

        private static int GetRandomNumber(int minSize, int maxSize)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            int randomNumber = random.Next(minSize, maxSize);
            return randomNumber;
        }
    }
}
