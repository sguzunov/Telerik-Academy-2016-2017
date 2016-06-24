namespace OrderStudents
{
    internal class Student
    {
        public Student(string firsName, string lastName)
        {
            this.FirstName = firsName;
            this.LastName = lastName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}
