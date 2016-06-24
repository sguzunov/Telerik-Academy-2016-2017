namespace StringBuilderSubstring
{
    /*
        Implement an extension method Substring(int index, int length) for the class 
        StringBuilder that returns new StringBuilder and has the same functionality as Substring in the class String.
    */

    using System;
    using System.Text;

    using Extensions;

    internal class StartUp
    {
        internal static void Main()
        {
            var text = new StringBuilder("Some text in StringBuilder.");

            // Throws exception. Index is negative.
            //Console.WriteLine(text.Substring(-1, 2));

            // Throws exception. Index is after the last element index.
            //Console.WriteLine(text.Substring(text.Length + 1, 2));

            // Throws exception. Length is too long.
            //Console.WriteLine(text.Substring(2, text.Length));

            // Returns whole text.
            Console.WriteLine(text.Substring(0, text.Length));

            // Return only 2 letters.
            Console.WriteLine(text.Substring(0, 2));
        }
    }
}
