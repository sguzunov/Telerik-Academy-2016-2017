using System;

namespace AnimalHierarchy.Models
{
    internal abstract class Animal : ISound
    {
        public Animal(string name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public abstract void ProduceSound(Action<string> action);
    }
}
