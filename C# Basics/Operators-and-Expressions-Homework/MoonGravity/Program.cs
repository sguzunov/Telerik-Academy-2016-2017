namespace MoonGravity
{
    /*
        The gravitational field of the Moon is approximately 17% of that on the Earth.
        Write a program that calculates the weight of a man on the moon by a given weight W(as a floating-point number) on the Earth.
        The weight W should be read from the console.
     */

    using System;
    using System.Globalization;
    using System.Threading;

    class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            double weightOnEarth = double.Parse(Console.ReadLine());
            double weightOnMoon = weightOnEarth * 0.17;
            Console.WriteLine("{0:F3}", weightOnMoon);
        }
    }
}