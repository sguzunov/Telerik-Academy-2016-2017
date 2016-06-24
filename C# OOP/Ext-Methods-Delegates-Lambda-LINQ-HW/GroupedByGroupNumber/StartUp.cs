namespace GroupedByGroupNumber
{
    // Create a program that extracts all students grouped by GroupNumber and then prints them to the console.
    // Use LINQ.

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using StudentGroups;

    internal class StartUp
    {
        static void Main()
        {
            // Using the class student from project StudentGroups.

            Student[] students =
            {
                new Student("John", "Doe", "111106","02222333", "John.Doe@abv.bg", new List<int>() { 5, 6}, 1),
                new Student("John", "Snow", "111222","02222444", "John.Snow@abv.bg", new List<int>() { 5, 5, 5}, 2),
                new Student("Asya", "Melon", "111333","02222555", "Melon@yandex.com", new List<int>() { 5, 2}, 2),
                new Student("Will", "Smith", "111444","02444565", "WillS@gmail.com", new List<int>() { 6, 6, 6}, 3),
                new Student("Will", "Morison", "111506","020202", "Morison.Will@yahoo.bg", new List<int>() { 5, 4, 4}, 4),
                new Student("Liam", "Nilson", "111666","0246464", "LN@abv.bg", new List<int>() { 6, 5, 6}, 2)
            };

            // Task 18. Grouped by GroupNumber.
            //var groupedByGroupNumber =
            //    from student in students
            //    group student by student.GroupNumber;

            // Task 18. Grouped by GroupNumber.
            var groupedByGroupNumber = students.GroupBy(st => st.GroupNumber);

            foreach (var group in groupedByGroupNumber)
            {
                Console.WriteLine("---" + group.Key + "---");
                foreach (var student in group)
                {
                    Console.WriteLine(student.FirstName + " " + student.LastName);
                }
            }
        }
    }
}
