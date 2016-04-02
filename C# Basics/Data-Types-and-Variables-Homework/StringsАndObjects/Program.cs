using System;

namespace StringsАndObjects
{
    class Program
    {
        static void Main()
        {
            string greeting = "Hello";
            string subject = "World";
            object concatenatedStringsInObject = greeting + " " + subject;
            string result = (string)concatenatedStringsInObject;

            Console.WriteLine(result);
        }
    }
}
