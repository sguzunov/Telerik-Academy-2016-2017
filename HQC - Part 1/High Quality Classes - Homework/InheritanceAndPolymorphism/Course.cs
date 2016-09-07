namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using InheritanceAndPolymorphism.Contracts;

    public abstract class Course : ICourse
    {
        private readonly IList<IStudent> students;

        public Course(string name, string teacherName)
        {
            this.Name = name;
            this.TecherName = teacherName;
            this.students = new List<IStudent>();
        }
        
        public string Name { get; set; }

        public IEnumerable<IStudent> Students
        {
            get
            {
                return this.students;
            }
        }

        public string TecherName { get; private set; }

        public void AddStudent(IStudent student)
        {
            if (student == null)
            {
                throw new ArgumentNullException($"Student cannot be null!");
            }

            if (this.students.Contains(student))
            {
                throw new ArgumentException($"Student is already added in course: {this.Name}!");
            }

            this.students.Add(student);
        }

        public bool RemoveStudent(IStudent student)
        {
            if (student == null)
            {
                throw new ArgumentNullException($"Student cannot be null!");
            }

            bool isRemoved = this.students.Remove(student);

            return isRemoved;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            if (this.Name != null)
            {
                builder.Append($"{this.GetType().Name} {{ Name = {this.Name};");
            }

            if (this.TecherName != null)
            {
                builder.Append($" Teacher = {this.TecherName};");
            }

            if (this.students != null)
            {
                var studentsNames = this.students.Select(s => s.Name).ToList();
                string studentsNamesJoined = string.Join(", ", studentsNames);
                builder.Append($" Students = {{ {studentsNamesJoined} }};");
            }

            return builder.ToString();
        }
    }
}
