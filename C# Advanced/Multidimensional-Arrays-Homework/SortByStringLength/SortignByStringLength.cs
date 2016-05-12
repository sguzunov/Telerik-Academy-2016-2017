// You are given an array of strings. Write a method that sorts the array by the length of its elements (the number of characters composing them).

using System;

class SortignByStringLength
{
    static void Main(string[] args)
    {
        string[] elements = Console.ReadLine().Split(' ');

        Array.Sort(elements, (x, y) => x.Length.CompareTo(y.Length));
        Console.WriteLine(string.Join(" ", elements));
    }
}
