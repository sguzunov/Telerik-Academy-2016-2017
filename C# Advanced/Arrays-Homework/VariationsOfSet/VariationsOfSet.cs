// Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N].

using System;

class VariationsOfSet
{
    private static int[] variations;

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        variations = new int[k];
        Variate(0, n, k);
    }

    private static void Variate(int index, int n, int k)
    {
        if (index >= k)
        {
            Console.WriteLine(string.Join(", ", variations));
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                variations[index] = i + 1;
                Variate(index + 1, n, k);
            }
        }
    }
}
