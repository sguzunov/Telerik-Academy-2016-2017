namespace FallingRocks
{
    using System;
    using System.Collections.Generic;
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

            while (true)
            {
                if (isAlive)
                {
                    GameObject newStone = CreateNewStone();
                    stones.Add(newStone);

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
                else
                {
                    Console.WriteLine("LOOOSERRR :D:D:D");
                    Console.WriteLine("Your points: {0}", playerPoints);
                    break;
                }
            }
        }

        // TODO: Make a better precision!
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
            if (pressedKey.Key == ConsoleKey.LeftArrow && player.PositionOnConcole.x > 0)
            {
                player.PositionOnConcole.x--;
            }
            else if (pressedKey.Key == ConsoleKey.RightArrow && (player.PositionOnConcole.x + player.Sign.Length - 1) <= ConsoleWidth)
            {
                player.PositionOnConcole.x++;
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
            var playerStarPsition = new Position(PlayerStartPositionX - (PlayerSign.Length / 2), PlayerStartPositionY);
            var player = new GameObject(PlayerSign, playerStarPsition, PlayerColor);
            return player;
        }

        private static GameObject CreateNewStone()
        {
            int signIndex = GetRandomNumber(0, stoneSigns.Length - 1);
            string stoneSign = stoneSigns[signIndex];
            ConsoleColor color = EnemyColor;
            if (stoneSign == MoneySign)
            {
                color = MoneyColor;
            }

            int stoneStartPositionX = GetRandomNumber(0, Console.WindowWidth - 1);
            Position stonePosition = new Position(stoneStartPositionX, StoneStartPositionY);
            GameObject stone = new GameObject(stoneSign, stonePosition, color);
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
        }

        private static int GetRandomNumber(int minValue, int maxValue)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            int randomNumber = random.Next(minValue, maxValue);
            return randomNumber;
        }
    }
}
