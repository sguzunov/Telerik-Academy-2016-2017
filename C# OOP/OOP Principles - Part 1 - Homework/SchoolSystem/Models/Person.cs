namespace SchoolSystem.Models
{
    internal abstract class Person
    {
        private string firstName;
        private string lastName;

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                DataValidator.ValidateIfStringIsNullOrEmpty(value, "First name");
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                DataValidator.ValidateIfStringIsNullOrEmpty(value, "Last name");
                this.lastName = value;
            }
        }
    }
}
