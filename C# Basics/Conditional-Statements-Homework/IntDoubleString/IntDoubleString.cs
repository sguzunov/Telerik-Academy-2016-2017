/*
    Write a program that, depending on the first line of the input, reads an int, double or string variable.
        If the variable is int or double, the program increases it by one.
        If the variable is a string, the program appends * at the end.
        Print the result at the console. Use switch statement.
*/

using System;
using System.Globalization;
using System.Threading;

class IntDoubleString
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        string type = Console.ReadLine();
        string value = Console.ReadLine();

        if (type == "integer" || type == "int")
        {
            int valueAsNumber = int.Parse(value);
            Console.WriteLine(valueAsNumber + 1);
        }
        else if (type == "double" || type == "real")
        {
            float valueAsRealNumber = float.Parse(value);
            Console.WriteLine("{0:F2}", valueAsRealNumber + 1);
        }
        else
        {
            Console.WriteLine(value + "*");
        }
    }
}
