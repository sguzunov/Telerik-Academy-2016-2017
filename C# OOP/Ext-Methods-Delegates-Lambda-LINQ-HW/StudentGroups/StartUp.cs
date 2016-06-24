namespace StudentGroups
{
    // Create a class Student with properties FirstName, LastName, FN, Tel, Email, Marks (a List), GroupNumber.
    // Create a List<Student> with sample students.Select only the students that are from group number 2.
    // Use LINQ query.Order the students by FirstName.

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
                new Student("John", "Doe", "111106","02222333", "John.Doe@abv.bg", new List<int>() { 5, 6}, 1),
                new Student("John", "Snow", "111222","02222444", "John.Snow@abv.bg", new List<int>() { 5, 5, 5}, 2),
                new Student("Asya", "Melon", "111333","02222555", "Melon@yandex.com", new List<int>() { 5, 2}, 2),
                new Student("Will", "Smith", "111444","02444565", "WillS@gmail.com", new List<int>() { 6, 6, 6}, 3),
                new Student("Will", "Morison", "111506","020202", "Morison.Will@yahoo.bg", new List<int>() { 5, 4, 4}, 4),
                new Student("Liam", "Nilson", "111666","0246464", "LN@abv.bg", new List<int>() { 6, 5, 6}, 2)
            };

            // Task 9
            //var fromGroup2AndOrderedByFirstName =
            //    from student in students
            //    where student.GroupNumber == 2
            //    orderby student.FirstName
            //    select student;

            // Task 10
            var fromGroup2AndOrderedByFirstName = students.Where(x => x.GroupNumber == 2)
                .OrderBy(s => s.FirstName);

            Console.WriteLine("--Task 9 and 10--");
            foreach (var student in fromGroup2AndOrderedByFirstName)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }

            // Task 11
            string emailDomain = "abv.bg";
            var extractedByEmailDomain = ExtractByEmailDomain(emailDomain, students);

            Console.WriteLine("\r\n--Task 11--");
            foreach (var student in extractedByEmailDomain)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }

            // Task 12
            // TODO: Implement

            // Task 13. Extract students by marks
            var excellentStudents = students.Where(st => st.Marks.Any(m => m == 6))
                .Select(st => new { FullName = st.FirstName + " " + st.LastName, Marks = st.Marks });

            Console.WriteLine("\r\n--Task 13--");
            foreach (var student in excellentStudents)
            {
                Console.WriteLine(student.FullName);
                Console.WriteLine(string.Join(" ", student.Marks));
            }

            // Task 14. Write down a similar program that extracts the students with exactly two marks "2".
            var studentsWithOnlyTwoMarks = students.Where(st => st.Marks.Count == 2);

            Console.WriteLine("\r\n--Task 14--");
            foreach (var student in studentsWithOnlyTwoMarks)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
                Console.WriteLine(string.Join(" ", student.Marks));
            }

            // Task 15. Extract all Marks of the students that enrolled in 2006.
            var studentsEnrolledIn2006 = students.Where(st => st.FacultyNumber[4] == '0' && st.FacultyNumber[5] == '6');

            Console.WriteLine("\r\n--Task 15--");
            foreach (var student in studentsEnrolledIn2006)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
        }

        // Task 11. Extract students by email.
        private static List<Student> ExtractByEmailDomain(string emailDomain, IEnumerable<Student> students)
        {
            var extractedStudents = students.Where(st =>
            {
                int atIndex = st.Email.IndexOf("@");
                return st.Email.IndexOf(emailDomain) - 1 == atIndex;
            }).ToList();

            return extractedStudents;
        }
    }
}
