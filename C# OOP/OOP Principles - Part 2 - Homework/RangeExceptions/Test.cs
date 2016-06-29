namespace RangeExceptions
{
    using System;

    internal class Test
    {
        private static void Main()
        {
            Person person;

            // Throws InvalidRangeException.
            // person = new Person("John", "Throw", -8);

            // Throws InvalidRangeException.
            // person = new Person("John", "Throw", 151);

            // Does not throw InvalidRangeException.
            person = new Person("John", "Nottrow", 30);

            Event ev;
            // Throws InvalidRangeException.
            //ev = new Event(new System.DateTime(1979, 05, 05));

            // Does not throw InvalidRangeException.
            ev = new Event(new DateTime(1989, 05, 05));
        }
    }
}
