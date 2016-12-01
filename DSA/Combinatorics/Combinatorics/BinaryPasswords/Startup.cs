using System;

namespace BinaryPasswords
{
    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            int stars = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '*') stars++;
            }

            ulong numberOfPasswords = 1U;
            for (int i = 0; i < stars; i++)
            {
                numberOfPasswords *= 2U;
            }

            Console.WriteLine(numberOfPasswords);
        }
    }
}
