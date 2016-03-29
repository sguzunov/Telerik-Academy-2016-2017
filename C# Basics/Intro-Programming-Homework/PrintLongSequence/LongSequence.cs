namespace PrintLongSequence
{
    using System;

    class LongSequence
    {
        static void Main()
        {
            int n = 1000;
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i + 2);
                    continue;
                }

                Console.WriteLine((i + 2) * -1);
            }
        }
    }
}
