namespace InheritanceAndPolymorphism
{
    using System.Text;
    using InheritanceAndPolymorphism.Contracts;

    public class OffsiteCourse : Course, IOffsiteCourse
    {
        public OffsiteCourse(string name, string teacherName, string town) : base(name, teacherName)
        {
            this.Town = town;
        }

        public string Town { get; private set; }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.Append(base.ToString());
            if (this.Town != null)
            {
                builder.Append($" Town: {this.Town};");
            }

            builder.Append(" }");

            return builder.ToString();
        }
    }
}
