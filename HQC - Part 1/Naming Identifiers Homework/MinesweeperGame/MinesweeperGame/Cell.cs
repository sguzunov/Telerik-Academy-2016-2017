namespace MinesweeperGame
{
    public class Cell : ICell
    {
        public bool HasMine { get; set; } = false;

        public int MinesAround { get; set; } = 0;

        public bool Popped { get; set; } = false;
    }
}
