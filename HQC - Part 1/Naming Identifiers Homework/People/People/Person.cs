namespace People
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public override string ToString()
        {
            var personAsString = $"Name: {this.Name}, Age: {this.Age}, Gender: {this.Gender}";

            return personAsString;
        }
    }
}
