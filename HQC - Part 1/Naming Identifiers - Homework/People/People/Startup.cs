namespace People
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var personFactory = new PersonFactory();
            var malePerson = personFactory.CreatePerson(20);
            var femalePerson = personFactory.CreatePerson(21);

            Console.WriteLine(malePerson);
            Console.WriteLine(femalePerson);
        }
    }
}
