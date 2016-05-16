// Write a method that asks the user for his name and prints Hello, <name>!. Write a program to test this method.

using System;

class SayHello
{
    private static void SayName(string name)
    {
        Console.WriteLine("Hello, {0}!", name);
    }

    static void Main()
    {
        string name = Console.ReadLine();
        SayName(name);
    }
}
