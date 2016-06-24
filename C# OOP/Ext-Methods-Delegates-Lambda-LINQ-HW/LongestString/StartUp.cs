namespace LongestString
{
    // Write a program to return the string with maximum length from an array of strings.
    // Use LINQ.

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class StartUp
    {
        static void Main()
        {
            string[] randomStrings =
            {
                "Long string",
                "Long long string",
                "Long long long string",
                "Long long long long string",
                "Long long long long long long long long string",
            };

            string longestString = randomStrings.FirstOrDefault(st => st.Length == (randomStrings.Max(s => s.Length)));
            Console.WriteLine(longestString);
        }
    }
}
