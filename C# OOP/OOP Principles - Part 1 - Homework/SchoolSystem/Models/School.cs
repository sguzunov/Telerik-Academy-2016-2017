namespace SchoolSystem.Models
{
    using System;
    using System.Collections.Generic;

    using SchoolSystem.Models.Contracts;

    internal abstract class School : ISchool
    {
        private string name;

        public string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                DataValidator.ValidateIfStringIsNullOrEmpty(value, "School name");
                this.name = value;
            }
        }

        public IList<ISchoolClass> SchoolClasses { get; set; }

        public void AddClass(ISchoolClass schoolClass)
        {
            DataValidator.ValidateIfObject(schoolClass, "School class");
            if (this.SchoolClasses.Contains(schoolClass))
            {
                throw new ArgumentException(string.Format("{0} class already exists!", schoolClass.Identifier));
            }

            this.SchoolClasses.Add(schoolClass);
        }

        public void RemoveClass(ISchoolClass schoolClass)
        {
            DataValidator.ValidateIfObject(schoolClass, "School class");
            if (!this.SchoolClasses.Contains(schoolClass))
            {
                throw new ArgumentException(string.Format("{0} does not exists!", schoolClass.Identifier));
            }

            this.SchoolClasses.Remove(schoolClass);
        }
    }
}
