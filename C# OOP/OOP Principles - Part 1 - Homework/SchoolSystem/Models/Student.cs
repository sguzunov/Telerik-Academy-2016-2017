namespace SchoolSystem.Models
{
    internal class Student : Person
    {
        public Student(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public Student(string firstName, string lastName, int classNumber) : this(firstName, lastName)
        {
            this.ClassNumber = classNumber;
        }

        public int ClassNumber { get; set; }
    }
}
