namespace PrintAge
{
    using System;
    using System.Globalization;
    class Age
    {
        static void Main()
        {
            string dateAsString = Console.ReadLine();
            DateTime dateOfBirth = DateTime.Parse(dateAsString, CultureInfo.InvariantCulture);

            DateTime today = DateTime.Today;
            int age = today.Year - dateOfBirth.Year;

            if (dateOfBirth > today.AddYears(-age))
            {
                age--;
            }

            Console.WriteLine(age);
            Console.WriteLine(age + 10);
        }
    }
