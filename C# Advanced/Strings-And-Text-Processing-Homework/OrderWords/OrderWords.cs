using System;
using System.Collections.Generic;
using System.Linq;

class OrderWords
{
    static void Main()
    {
        string[] words = Console.ReadLine().Split(' ');

        var orderedWords = words.OrderBy(x => x);
        Console.WriteLine(string.Join(" ", orderedWords));
    }
}
