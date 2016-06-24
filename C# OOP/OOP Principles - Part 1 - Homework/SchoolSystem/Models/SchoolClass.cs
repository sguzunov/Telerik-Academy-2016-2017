namespace SchoolSystem.Models
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    internal class SchoolClass : ISchoolClass
    {
        private string identifier;

        public SchoolClass(string identifier, params Teacher[] teachers)
        {
            this.Identifier = identifier;
            this.Teachers = teachers;
            this.Teachers = new List<Teacher>();
        }

        public string Identifier
        {
            get
            {
                return this.identifier;
            }

            private set
            {
                DataValidator.ValidateIfStringIsNullOrEmpty(value, "Identifier");
                this.identifier = value;
            }
        }

        public IList<Teacher> Teachers { get; private set; }

        public void AddTeacher(Teacher teacher)
        {
            DataValidator.ValidateIfObject(teacher, "Teacher");
            if (this.Teachers.Contains(teacher))
            {
                throw new ArgumentException(string.Format("Teacher {0} already exists!", teacher.FirstName + " " + teacher.LastName));
            }

            this.Teachers.Add(teacher);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            DataValidator.ValidateIfObject(teacher, "Teacher");
            if (!this.Teachers.Contains(teacher))
            {
                throw new ArgumentException(string.Format("Teacher {0} does not exists!", teacher.FirstName + " " + teacher.LastName));
            }

            this.Teachers.Remove(teacher);
        }
    }
}
