namespace FirstBeforeLast
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        static void Main()
        {
            Student[] students =
            {
                new Student("Angel", "Ivanov"),
                new Student("Ivan", "Angelov"),
                new Student("Stanimira", "Yaneva"),
                new Student("Yana", "Stanimirova")
            };

            var firstBeforeLast =
                from student in students
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;

            foreach (var student in firstBeforeLast)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
        }
    }
}
