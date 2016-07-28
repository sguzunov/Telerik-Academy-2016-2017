namespace SchoolSystem
{
    using System;
    using System.Collections.Generic;

    using SchoolSystem.Contracts;

    public class Course : ICourse
    {
        private const int CourseCapacity = 29;

        private readonly ICollection<IStudent> students;

        private string name;

        public Course(string name)
        {
            this.Name = name;
            this.students = new List<IStudent>();
        }

        public string Name
        {
            get
            {
                return name;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Course's name cannot be null", "Name");
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException("Course's name cannot be empty string", "Name");
                }

                this.name = value;
            }
        }

        public void AddStudent(IStudent student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student", "Course cannot add null student!");
            }

            if (this.students.Contains(student))
            {
                throw new InvalidOperationException("Student cannot assign a course more then once!");
            }

            if (this.students.Count + 1 > CourseCapacity)
            {
                throw new InvalidOperationException("Course is full!");
            }

            this.students.Add(student);
        }

        public bool RemoveStudent(IStudent student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student", "Course cannot remove null student");
            }

            if (this.students.Count == 0)
            {
                throw new InvalidOperationException("Corse is empty. Cannot remove a student!");
            }

            return this.students.Remove(student);
        }
    }
}
