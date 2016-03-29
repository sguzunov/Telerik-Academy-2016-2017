namespace PrintSequence
{
    using System;

    class Sequence
    {
        static void Main()
        {
            int n = 10;
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i + 2);
                }
                else
                {
                    Console.WriteLine((i + 2) * -1);
                }
            }
        }
    }
}
