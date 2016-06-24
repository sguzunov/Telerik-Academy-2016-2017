namespace AgeRange
{
    // Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class StartUp
    {
        static void Main()
        {
            Student[] students =
            {
                new Student("John", "Snow", 18),
                new Student("Snow", "John", 24),
                new Student("Alan", "Smith", 20),
                new Student("Raya", "Snow", 30),
                new Student("Jim", "Cary", 17),
            };

            var studentsInRange =
                from student in students
                where student.Age >= 18 && student.Age <= 24
                select new { FirstName = student.FirstName, LastName = student.LastName };

            foreach (var student in studentsInRange)
            {
                Console.WriteLine(student);
            }
        }
    }
}
