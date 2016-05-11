/*
    Write a program that reads an array of integers and removes from it a minimal number of elements in such a way that the remaining array is sorted in increasing order. Print the minimal number of elements that need to be removed in order for the array to become sorted.
 */

using System;
using System.Diagnostics;

class RemoveElementsFromArray
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int len = FindLongestSubsequence(numbers);
        Console.WriteLine(numbers.Length - len);
    }

    private static int FindLongestSubsequence(int[] numbers)
    {
        int i, j;
        int l; /* В момента на разглеждане на xi,
                /* l е дължината на максималната подредица с начало xj: */
               /* 1) i < j <= n и */
               /* 2) xi <= xj */

        int[] lns = new int[numbers.Length];
        int len = 0; /* Максимална (за момента) дължина на подредица */
        for (i = numbers.Length - 1; i >= 0; i--)
        {
            for (l = 0, j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[j] >= numbers[i] && lns[j] > l)
                {
                    l = lns[j];
                }
            }

            lns[i] = l + 1;
            if (lns[i] > len)
            {
                len = lns[i];
            }
        }

        return len;
    }

    //private static int FindLongestSubsequence(int[] numbers)
    //{
    //    int maxSubsequence = 0;
    //    for (int i = 1; i < numbers.Length; i++)
    //    {
    //        int currentMaxSubsequence = 0;
    //        int right = numbers[i];
    //        for (int j = 0; j < i; j++)
    //        {
    //            currentMaxSubsequence = 0;
    //            int left = numbers[j];
    //            if (left <= right)
    //            {
    //                int prevNumber = left;
    //                int max = 1;
    //                for (int k = j + 1; k < i; k++)
    //                {
    //                    int number = numbers[k];
    //                    if (prevNumber <= number && number <= right)
    //                    {
    //                        max++;
    //                        prevNumber = number;
    //                    }
    //                }

    //                if (max > currentMaxSubsequence)
    //                {
    //                    currentMaxSubsequence = max;
    //                }
    //            }

    //            if (currentMaxSubsequence > maxSubsequence)
    //            {
    //                maxSubsequence = currentMaxSubsequence;
    //            }
    //        }
    //    }

    //    return maxSubsequence + 1;
    //}

    // Resursive.
    //private static void FindLongestSubsequence(int index, int prevElement, int currentSequence, int[] numbers)
    //{
    //    int currentElement = numbers[index];
    //    if (currentElement >= prevElement)
    //    {
    //        currentSequence++;
    //        if (currentSequence > maxSubSequence)
    //        {
    //            maxSubSequence = currentSequence;
    //        }

    //        prevElement = currentElement;
    //    }

    //    if (maxSubSequence < (numbers.Length - index) + currentSequence)
    //    {
    //        for (int i = index + 1; i < numbers.Length; i++)
    //        {
    //            FindLongestSubsequence(i, prevElement, currentSequence, numbers);
    //            FindLongestSubsequence(i, int.MinValue, 0, numbers);
    //        }
    //    }
    //}
}
