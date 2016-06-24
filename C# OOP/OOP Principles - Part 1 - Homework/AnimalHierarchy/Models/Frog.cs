namespace AnimalHierarchy.Models
{
    using System;

    internal class Frog : Animal
    {
        public Frog(string name, int age, Gender gender) : base(name, age, gender)
        {
        }

        public override void ProduceSound(Action<string> action)
        {
            action("Frog From...");
        }
    }
}
