// Write a method that adds two polynomials. Represent them as arrays of their coefficients. Write a program that reads two polynomials and prints their sum.

using System;
using System.Linq;

class AddingSubtractingMultiplyingPolynomials
{
    private static int[] SumPlynomialCoeficents(int[] firstPolynomialCoef, int[] secondPolynomialCoef, int coeficentsCount)
    {
        int[] result = new int[coeficentsCount];
        for (int i = 0; i < coeficentsCount; i++)
        {
            result[i] = firstPolynomialCoef[i] + secondPolynomialCoef[i];
        }

        return result;
    }

    private static int[] SubstractPlynomialCoeficents(int[] firstPolynomialCoef, int[] secondPolynomialCoef, int coeficentsCount)
    {
        int[] result = new int[coeficentsCount];
        for (int i = 0; i < coeficentsCount; i++)
        {
            result[i] = firstPolynomialCoef[i] - secondPolynomialCoef[i];
        }

        return result;
    }

    private static int[] MultiplyPlynomialCoeficents(int[] firstPolynomialCoeficents, int[] secondPolynomialCoeficents, int coeficentsCount)
    {
        int firstPolynomialMaxPower = GetMaxPower(firstPolynomialCoeficents);
        int secondPolynomialMaxPower = GetMaxPower(secondPolynomialCoeficents);

        int[] multipluedCoeficents = new int[firstPolynomialMaxPower + secondPolynomialMaxPower + 1];
        int firstPolynomialPower = firstPolynomialCoeficents.Length - 1;
        for (int i = firstPolynomialCoeficents.Length - 1; i >= 0; i--)
        {
            int firstCoef = firstPolynomialCoeficents[i];
            if (firstCoef != 0)
            {
                int secondPolynomialPower = secondPolynomialCoeficents.Length - 1;
                for (int j = secondPolynomialCoeficents.Length - 1; j >= 0; j--)
                {
                    int secondCoef = secondPolynomialCoeficents[j];
                    if (secondCoef != 0)
                    {
                        int product = firstCoef * secondCoef;
                        multipluedCoeficents[firstPolynomialPower + secondPolynomialPower] += product;
                    }

                    secondPolynomialPower--;
                }
            }

            firstPolynomialPower--;
        }

        return multipluedCoeficents;
    }

    private static int GetMaxPower(int[] polynomialCoef)
    {
        int power = 0;
        for (int i = polynomialCoef.Length - 1; i >= 0; i--)
        {
            if (polynomialCoef[i] != 0)
            {
                power = i;
                break;
            }
        }

        return power;
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] firstPolynomialCoef = new int[n];
        firstPolynomialCoef = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        int[] secondPolynomialCoef = new int[n];
        secondPolynomialCoef = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

        int[] sumedCoef = SumPlynomialCoeficents(firstPolynomialCoef, secondPolynomialCoef, n);
        int[] substractedCoef = SubstractPlynomialCoeficents(firstPolynomialCoef, secondPolynomialCoef, n);
        int[] multipliedCoef = MultiplyPlynomialCoeficents(firstPolynomialCoef, secondPolynomialCoef, n);


        Console.WriteLine("Summed coeficents: " + string.Join(" ", sumedCoef));
        Console.WriteLine("Substracted coeficents: " + string.Join(" ", substractedCoef));
        Console.WriteLine("Multiplied coeficents: " + string.Join(" ", multipliedCoef));
    }
}
