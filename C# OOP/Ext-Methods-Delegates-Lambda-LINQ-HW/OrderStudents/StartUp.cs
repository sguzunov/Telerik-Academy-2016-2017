namespace OrderStudents
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        static void Main()
        {
            Student[] students =
            {
                new Student("John", "Doe"),
                new Student("John", "Snow"),
                new Student("Asya", "Melon"),
                new Student("Will", "Smith"),
                new Student("Will", "Morison"),
                new Student("Liam", "Nilson")
            };

            //var orderedStudentsByFirstAndLastName = students.OrderByDescending(s => s.FirstName).ThenByDescending(s => s.LastName);

            var orderedStudentsByFirstAndLastName =
                from student in students
                orderby student.FirstName descending, student.LastName descending
                select student;

            foreach (var student in orderedStudentsByFirstAndLastName)
            {
                Console.WriteLine(student);
            }
        }
    }
}
