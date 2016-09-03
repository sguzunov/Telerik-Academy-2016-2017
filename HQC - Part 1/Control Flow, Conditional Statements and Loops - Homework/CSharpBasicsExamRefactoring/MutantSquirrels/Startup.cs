namespace MutantSquirrels
{
    using System;
    using System.Globalization;
    using System.Threading;

    public class Startup
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            ulong trees = ulong.Parse(Console.ReadLine());
            ulong branches = ulong.Parse(Console.ReadLine());
            ulong squirrelsOnABranch = ulong.Parse(Console.ReadLine());
            ulong tailsForASquirrel = ulong.Parse(Console.ReadLine());

            double totalSquirrels = trees * branches * squirrelsOnABranch * tailsForASquirrel;
            if (totalSquirrels % 2 == 0)
            {
                Console.WriteLine("{0:F3}", totalSquirrels * 376439);
            }
            else
            {
                Console.WriteLine("{0:F3}", totalSquirrels / 7.0);
            }
        }
    }
}
