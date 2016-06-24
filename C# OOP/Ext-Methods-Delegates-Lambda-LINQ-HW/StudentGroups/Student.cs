namespace StudentGroups
{
    using System.Collections.Generic;

    public class Student
    {
        public Student()
        {
            this.Marks = new List<int>();
        }

        public Student(string firstName, string lastName, int groupNumber) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            this.GroupNumber = groupNumber;
        }

        public Student(string firstName, string lastName, string facultyNumber, string telefon, string email, IList<int> marks, int groupNumber) : this(firstName, lastName, groupNumber)
        {
            FacultyNumber = facultyNumber;
            Telefon = telefon;
            Email = email;
            Marks = marks;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FacultyNumber { get; set; }

        public string Telefon { get; set; }

        public string Email { get; set; }

        public IList<int> Marks { get; private set; }

        public int GroupNumber { get; set; }
    }
}
