namespace StudentsAndWorkers.Models
{
    using StudentsAndWorkers.Models.Contracts;

    internal class Student : Human, IStudent
    {
        public Student(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public Student(string firstName, string lastName, int grade) : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public int Grade { get; set; }
    }
}
