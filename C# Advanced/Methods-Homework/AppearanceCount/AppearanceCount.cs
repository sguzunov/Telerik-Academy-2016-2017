// Write a method that counts how many times given number appears in a given array. Write a test program to check if the method is working correctly.

using System;
using System.Linq;

class AppearanceCount
{
    private static int CountNumberAppearance(int checkedNumber, int[] numbers)
    {
        int counter = 0;
        foreach (int number in numbers)
        {
            if (checkedNumber == number)
            {
                counter++;
            }
        }

        return counter;
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        numbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

        int checkedNumber = int.Parse(Console.ReadLine());

        int appearanceCount = CountNumberAppearance(checkedNumber, numbers);
        Console.WriteLine(appearanceCount);
    }
}
