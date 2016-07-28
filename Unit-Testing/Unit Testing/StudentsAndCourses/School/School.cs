namespace SchoolSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    public class School : ISchool
    {
        private readonly ICollection<IStudent> students;
        private readonly ICollection<ICourse> courses;

        public School()
        {
            this.students = new List<IStudent>();
            this.courses = new List<ICourse>();
        }

        public void AddCourse(ICourse course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("course", "School cannot add null course!");
            }

            if (this.courses.Contains(course))
            {
                throw new InvalidOperationException("School already has this course!");
            }

            this.courses.Add(course);
        }

        public void AddStudent(IStudent student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student", "School cannot add null student!");
            }

            if (this.students.Contains(student))
            {
                throw new InvalidOperationException("School already has this student!");
            }

            if (this.students.Any(st => st.Id == student.Id))
            {
                throw new ArgumentException("Students in school should have a unique number!");
            }

            this.students.Add(student);
        }

        public bool RemoveCourse(ICourse course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("course", "School cannot remove null course!");
            }

            if (this.courses.Count == 0)
            {
                throw new InvalidOperationException("School has no courses!");
            }

            return this.courses.Remove(course);
        }

        public bool RemoveStudent(IStudent student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student", "School cannot remove null student");
            }

            if (this.students.Count == 0)
            {
                throw new InvalidOperationException("School has no students!");
            }

            return this.students.Remove(student);
        }
    }
}
