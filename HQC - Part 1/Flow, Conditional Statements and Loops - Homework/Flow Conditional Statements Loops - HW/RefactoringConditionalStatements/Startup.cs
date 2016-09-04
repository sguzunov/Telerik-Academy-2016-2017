namespace RefactoringConditionalStatements
{
    public class Startup
    {
        public static void Main()
        {
            // Potato example
            Potato potato;
            potato = new Potato();
            if (potato != null && (potato.IsPeeled && potato.IsRooten == false))
            {
                Cook(potato);
            }

            // Cell example
            const int MinXCoordinate = 1;
            const int MaxXCoordinate = 100;
            const int MinYCoordinate = 2;
            const int MaxYCoordinate = 200;

            var cell = new Cell(10, 120);
            bool isInRange = (MinXCoordinate <= cell.XCoordinate && cell.XCoordinate <= MaxXCoordinate) &&
                (MinYCoordinate <= cell.YCoordinate && cell.YCoordinate <= MaxYCoordinate);
            if (isInRange && !cell.Isvisited)
            {
                cell.Isvisited = true;
            }
        }

        private static void Cook(Potato potato)
        {
            // Cooking the potato.
        }
    }
}
