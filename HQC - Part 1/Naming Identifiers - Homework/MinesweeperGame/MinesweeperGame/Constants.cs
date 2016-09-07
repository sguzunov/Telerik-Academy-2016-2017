namespace MinesweeperGame
{
    public class Constants
    {
        public const string ScorePrintFormat = "{0}. {1} --> {2} cells";

        // Game commands.
        public const string ShowScoreboardCommand = "top";
        public const string StartANewGameCommand = "restart";
        public const string ExitGameCommand = "exit";
        public const string PopACellCommand = "turn";

        public const string UnpopedCell = "?";
        public const string CellWithoutMine = "-";
        public const string CellWithMine = "*";
    }
}
