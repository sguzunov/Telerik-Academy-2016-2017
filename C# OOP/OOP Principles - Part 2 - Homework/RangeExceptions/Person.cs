namespace RangeExceptions
{
    using RangeExceptions.Exceptions;

    internal class Person
    {
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 1 || value > 150)
                {
                    throw new InvalidRangeException<int>(string.Format("Person age {0} is invalid!", value), 1, 150);
                }

                this.age = value;
            }
        }
    }
}
