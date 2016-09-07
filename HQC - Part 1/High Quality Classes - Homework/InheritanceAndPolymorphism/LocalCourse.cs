namespace InheritanceAndPolymorphism
{
    using System.Text;
    using InheritanceAndPolymorphism.Contracts;

    public class LocalCourse : Course, ILocalCourse
    {
        public LocalCourse(string name, string teacherName, string lab) : base(name, teacherName)
        {
            this.Lab = lab;
        }

        public string Lab { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.Append(base.ToString());
            if (this.Lab != null)
            {
                builder.Append($" Lab: {this.Lab};");
            }

            builder.Append(" }");

            return builder.ToString();
        }
    }
}
