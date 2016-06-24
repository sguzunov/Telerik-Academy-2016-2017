namespace AnimalHierarchy.Models
{
    internal class Kitty : Cat
    {
        public Kitty(string name, int age) : base(name, age, Gender.Female)
        {
        }
    }
}
