// Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N].

using System;

class CombinationsOfSet
{
    private static int[] combination;

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        combination = new int[k];
        Combine(0, 0, n, k);
    }

    private static void Combine(int index, int after, int n, int k)
    {
        if (index >= k)
        {
            Console.WriteLine(string.Join(", ", combination));
        }
        else
        {
            for (int i = after + 1; i <= n; i++)
            {
                combination[index] = i;
                Combine(index + 1, i, n, k);
            }
        }
    }
}
