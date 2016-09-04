namespace RefactoringConditionalStatements
{
    public class Cell
    {
        public Cell(int xCoordinate, int yCoordinate)
        {
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
        }

        public int XCoordinate { get; }

        public int YCoordinate { get; }

        public bool Isvisited { get; set; } = false;
    }
}
