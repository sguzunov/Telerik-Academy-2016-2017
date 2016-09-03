namespace Bunnies.Contracts
{
    public interface IBunny
    {
        string Name { get; set; }

        int Age { get; set; }

        FurType FurType { get; set; }

        void Introduce(IWriter writer);
    }
}
