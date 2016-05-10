// Write a program that finds the most frequent number in an array of N elements.

using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(numbers);
        int mostFrequentNumber = 0;
        int repeatedTimes = int.MinValue;
        int currentRepeatedTimes = 1;
        int lastNumber = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] == lastNumber)
            {
                currentRepeatedTimes++;
            }
            else
            {
                currentRepeatedTimes = 1;
            }

            if (currentRepeatedTimes > repeatedTimes)
            {
                repeatedTimes = currentRepeatedTimes;
                mostFrequentNumber = lastNumber;
            }

            lastNumber = numbers[i];
        }

        Console.WriteLine("{0} ({1} times)", mostFrequentNumber, repeatedTimes);
    }
}
