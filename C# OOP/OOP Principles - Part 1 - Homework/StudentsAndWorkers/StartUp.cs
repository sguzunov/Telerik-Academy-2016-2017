namespace StudentsAndWorkers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;

    internal class StartUp
    {
        private static Random random = new Random();
        private static string[] randomFirstNames = { "Stamat", "Ivan", "Pesho", "Gosho", "Asen", "Iliyan" };
        private static string[] randomLastNames = { "Stamatov", "Ivanov", "Peshoov", "Goshoov", "Asenov", "Iliyanov" };

        static void Main()
        {
            // Test students.
            var students = GenerateStudents();
            var orderedByGrade = students.OrderBy(st => st.Grade);

            Console.WriteLine("--Students ordered by grade--");
            foreach (var student in orderedByGrade)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName + " " + student.Grade);
            }

            // Test workers.
            const int workDays = 5;
            var workers = GenerateWorkers();
            var orderedByMoneyPerHourByDes = workers.OrderByDescending(w => w.MoneyPerHour(workDays));

            Console.WriteLine("\r\n--Students ordered by grade--");
            foreach (var worker in orderedByMoneyPerHourByDes)
            {
                Console.WriteLine(worker.FirstName + " " + worker.LastName + " " + worker.MoneyPerHour(workDays));
            }

            List<Human> merged = new List<Human>();
            merged.AddRange(students);
            merged.AddRange(workers);

            var humansSortedByName = merged.OrderBy(h => h.FirstName).ThenBy(h => h.LastName);
            Console.WriteLine("\r\n--Merged and sorted--");
            foreach (var human in humansSortedByName)
            {
                Console.WriteLine(human.FirstName + " " + human.LastName);
            }
        }

        private static IList<Student> GenerateStudents()
        {
            IList<Student> students = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                string firstName = randomFirstNames[random.Next(0, randomFirstNames.Length)];
                string lastName = randomLastNames[random.Next(0, randomLastNames.Length)];
                int grade = random.Next(2, 7);
                students.Add(new Student(firstName, lastName, grade));
            }

            return students;
        }

        private static IList<Worker> GenerateWorkers()
        {
            IList<Worker> students = new List<Worker>();
            for (int i = 0; i < 10; i++)
            {
                string firstName = randomFirstNames[random.Next(0, randomFirstNames.Length)];
                string lastName = randomLastNames[random.Next(0, randomLastNames.Length)];
                byte workHoursPerDay = (byte)random.Next(6, 10);
                decimal weekSalary = (decimal)random.Next(300, 1000);
                students.Add(new Worker(firstName, lastName, workHoursPerDay, weekSalary));
            }

            return students;
        }
    }
}
