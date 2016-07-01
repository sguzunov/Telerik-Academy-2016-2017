namespace PersonClass
{
    using System.Text;

    internal class Person
    {
        private const string NameStringTemplate = "Name: {0}";
        private const string AgeStringTemplate = " Age: {0}";

        public Person(string name, int? age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int? Age { get; set; }

        public override string ToString()
        {
            var stringRepresentation = new StringBuilder();
            stringRepresentation.AppendFormat(NameStringTemplate, this.Name);
            if (this.Age != null)
            {
                stringRepresentation.AppendFormat(AgeStringTemplate, this.Age);
            }
            else
            {
                stringRepresentation.AppendFormat(AgeStringTemplate, "not specified");
            }

            return stringRepresentation.ToString();
        }
    }
}
