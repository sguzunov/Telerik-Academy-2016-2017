using System;

namespace ZigZag
{
    public class Startup
    {
        public static void Main()
        {
            string[] nk = Console.ReadLine().Split(' ');

            int n = int.Parse(nk[0]);
            int k = int.Parse(nk[1]);

            int count = 0;
            GenerateSequence(0, n, k, new int[k], new bool[n + 1], ref count);
            Console.WriteLine(count);
        }

        private static void GenerateSequence(int index, int n, int k, int[] seq, bool[] used, ref int count)
        {
            if (k <= index)
            {
                if (IsZigZagSequence(seq))
                {
                    count++;
                }

                return;
            }

            for (int i = 1; i <= n; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    seq[index] = i;
                    GenerateSequence(index + 1, n, k, seq, used, ref count);
                    used[i] = false;
                }
            }
        }

        private static bool IsZigZagSequence(int[] seq)
        {
            for (int i = 0; i < seq.Length; i++)
            {
                if (i % 2 != 0)
                {
                    int current = seq[i];
                    int prev = seq[i - 1];
                    if (i == seq.Length - 1)
                    {
                        if (!(current < prev))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        int next = seq[i + 1];
                        if (!(prev > current && current < next))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
