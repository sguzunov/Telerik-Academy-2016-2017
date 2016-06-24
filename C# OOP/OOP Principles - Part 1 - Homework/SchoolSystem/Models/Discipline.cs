namespace SchoolSystem.Models
{
    using Contracts;

    internal class Discipline : IDiscipline
    {
        private string name;
        private int numberOfExercises;

        public Discipline(string name, int numberOfExercises, int numberOfLectures)
        {
            this.Name = name;
            this.NumberOfExercises = numberOfExercises;
            this.NumberOfLectures = numberOfLectures;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                DataValidator.ValidateIfStringIsNullOrEmpty(value, "Name");
                this.name = value;
            }
        }

        public int NumberOfExercises { get; set; }

        public int NumberOfLectures { get; set; }
    }
}
