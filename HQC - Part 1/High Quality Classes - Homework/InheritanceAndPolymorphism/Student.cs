namespace InheritanceAndPolymorphism
{
    using InheritanceAndPolymorphism.Contracts;

    public class Student : IStudent
    {
        public Student(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
