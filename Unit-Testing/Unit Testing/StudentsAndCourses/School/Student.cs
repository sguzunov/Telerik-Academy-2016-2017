namespace SchoolSystem
{
    using System;

    using SchoolSystem.Contracts;

    public class Student : IStudent
    {
        private const int MinIdValue = 10000;
        private const int MaxIdValue = 99999;

        private string firstName;
        private string lastName;
        private int id;

        public Student(string firstName, string lastName, int id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("FirstName", "Student's first name cannot be null!");
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException("Student's first name cannot be empty string!", "FirstName");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("LastName", "Student's last name cannot be null!");
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException("Student's last name cannot be empty string!", "LastName");
                }

                this.lastName = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            private set
            {
                if (value < MinIdValue || value > MaxIdValue)
                {
                    throw new ArgumentOutOfRangeException(
                        "Id",
                        string.Format("Student's id must be in range [{0}, {1}]", MinIdValue, MaxIdValue));
                }

                this.id = value;
            }
        }
    }
}
