namespace ArmyOfCreatures.UnitTests.Fakes
{
    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Battles;

    internal class BattleManagerFake : BattleManager
    {
        public BattleManagerFake(ICreaturesFactory creaturesFactory, ILogger logger) : base(creaturesFactory, logger)
        {
        }

        public ICreaturesInBattle FirstArmyCreature { get; set; }

        public ICreaturesInBattle SecondArmyCreature { get; set; }

        protected override ICreaturesInBattle GetByIdentifier(CreatureIdentifier identifier)
        {
            if (identifier.ArmyNumber == 1)
            {
                return this.FirstArmyCreature;
            }
            else if (identifier.ArmyNumber == 2)
            {
                return this.SecondArmyCreature;
            }

            return null;
        }
    }
}
