namespace PersonClass
{
    using System;

    class StartUp
    {
        static void Main()
        {
            var personWithAge = new Person("John", 26);
            Console.WriteLine(personWithAge);

            var personWithoutAge = new Person("John", null);
            Console.WriteLine(personWithoutAge);
        }
    }
}
