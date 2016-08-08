namespace ArmyOfCreatures.Logic
{
    public interface ICreatureIdentifier
    {
        string CreatureType { get; }

        int ArmyNumber { get; }
    }
}
