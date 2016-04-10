namespace PointInACircle
{
    using System;

    class Program
    {
        static void Main()
        {
            float x = float.Parse(Console.ReadLine());
            float y = float.Parse(Console.ReadLine());

            float radius = 2f;
            float xDistance = x >= 0 ? x : -x;
            float yDistance = y >= 0 ? y : -y;
            float distance = (float)Math.Sqrt(x * x + y * y);

            if (distance <= radius)
            {
                Console.WriteLine("yes {0:F2}", distance);
            }
            else
            {
                Console.WriteLine("no {0:F2}", distance);
            }
        }
    }
}
