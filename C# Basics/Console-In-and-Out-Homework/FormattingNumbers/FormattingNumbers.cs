using System;
using System.Globalization;
using System.Threading;

class Program
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        ushort firstNumber = ushort.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());
        double thirdNumber = double.Parse(Console.ReadLine());

        string firstNumberInHex = firstNumber.ToString("X");
        string firstNumberInBinary = Convert.ToString(firstNumber, 2).PadLeft(10, '0');
        Console.WriteLine("{0,-10}|{1}|{2,10:F2}|{3,10:F3}|", firstNumberInHex, firstNumberInBinary, secondNumber, thirdNumber);
    }
}
