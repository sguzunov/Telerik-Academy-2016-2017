namespace AnimalHierarchy.Models
{
    using System;

    internal abstract class Cat : Animal
    {
        public Cat(string name, int age, Gender gender) : base(name, age, gender)
        {
        }

        public override void ProduceSound(Action<string> action)
        {
            action("Mew Mew");
        }
    }
}
