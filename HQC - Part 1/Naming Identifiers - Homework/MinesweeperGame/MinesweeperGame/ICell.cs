namespace MinesweeperGame
{
    public interface ICell
    {
        int MinesAround { get; set; }

        bool Popped { get; set; }

        bool HasMine { get; set; }
    }
}
