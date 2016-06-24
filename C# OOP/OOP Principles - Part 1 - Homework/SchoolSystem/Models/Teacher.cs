namespace SchoolSystem.Models
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    internal class Teacher : Person, ITeacher
    {
        public Teacher(string firstName, string lastName) : base(firstName, lastName)
        {
            this.Disciplines = new List<IDiscipline>();
        }

        public Teacher(string firstName, string lastName, IList<IDiscipline> disciplines) : this(firstName, lastName)
        {
            this.Disciplines = disciplines;
        }

        public IList<IDiscipline> Disciplines { get; set; }

        public void AddDiscipline(IDiscipline discipline)
        {
            DataValidator.ValidateIfObject(discipline, "discipline");

            if (this.Disciplines.Contains(discipline))
            {
                throw new ArgumentException(string.Format("Discipline {0} already exists!", discipline.Name));
            }

            this.Disciplines.Add(discipline);
        }

        public void RemoveDiscipline(IDiscipline discipline)
        {
            DataValidator.ValidateIfObject(discipline, "discipline");

            if (!this.Disciplines.Contains(discipline))
            {
                throw new ArgumentException(string.Format("Discipline {0} does not exist!", discipline.Name));
            }

            this.Disciplines.Remove(discipline);
        }
    }
}
