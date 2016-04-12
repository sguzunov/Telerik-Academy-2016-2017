namespace FallingRocks
{
    using System;

    public class GameObject
    {
        public GameObject(string sign, Position position, ConsoleColor color)
        {
            this.Sign = sign;
            this.PositionOnConcole = position;
            this.Color = color;
        }

        public string Sign { get; set; }

        public ConsoleColor Color { get; set; }

        public Position PositionOnConcole { get; set; }
    }
}
