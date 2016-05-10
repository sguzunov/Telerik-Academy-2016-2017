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
        int n = numbers.Length;
        int[] sizes = new int[n];
        int max = 0;
        for (int i = 0; i < n; i++)
        {
            max = 0;
            for (int j = 0; j < i; j++)
            {
                if (numbers[i] > numbers[j] && sizes[j] > max)
                {
                    max = sizes[j];
                }

                sizes[i] = max + 1;
            }
        }

        max = 0;
        for (int i = 0; i < n; i++)
        {
            if (sizes[i] > max)
            {
                max = sizes[i];
            }
        }

        return max;
    }

    static public int LongestIncreasingSeq(int[] s)
    {
        int[] l = new int[s.Length];  // DP table for max length[i]
        int[] p = new int[s.Length];  // DP table for predeccesor[i]
        int max = int.MinValue;

        l[0] = 1;

        for (int i = 0; i < s.Length; i++)
            p[i] = -1;

        for (int i = 1; i < s.Length; i++)
        {
            l[i] = 1;
            for (int j = 0; j < i; j++)
            {
                if (s[j] < s[i] && l[j] + 1 > l[i])
                {
                    l[i] = l[j] + 1;
                    p[i] = j;
                    if (l[i] > max)
                        max = l[i];
                }
            }
        }
        return max;
    }

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
