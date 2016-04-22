using System;
using System.Numerics;

class CatalanNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        BigInteger factorialDoubleN = 1;
        BigInteger factorialNPlusOne = 1;
        BigInteger factorialN = 1;

        for (int i = 1; i <= (n * 2); i++)
        {
            factorialDoubleN *= i;
            if (i <= (n + 1))
            {
                factorialNPlusOne *= i;
            }

            if (i <= n)
            {
                factorialN *= i;
            }
        }

        Console.WriteLine(factorialDoubleN / (factorialNPlusOne * factorialN));
    }
}
