using System;

class BinarySearch
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(numbers);
        int index = Array.BinarySearch(numbers, k);
        if (index < 0)
        {
            index = index * (-1);
            if (index - 2 >= 0)
            {
                index--;
            }
        }

        Console.WriteLine(numbers[index - 1]);
    }
}
