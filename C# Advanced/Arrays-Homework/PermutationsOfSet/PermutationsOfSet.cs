// Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N].

using System;

class PermutationsOfSet
{
    private static bool[] used;
    private static int[] permutation;

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        used = new bool[n];
        permutation = new int[n];
        Permute(0, n);
    }

    private static void Permute(int index, int n)
    {
        if (index >= n)
        {
            Console.WriteLine(string.Join(", ", permutation));
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                if (!used[i])
                {
                    permutation[index] = i + 1;
                    used[i] = true;
                    Permute(index + 1, n);
                    used[i] = false;
                }
            }
        }
    }
}
