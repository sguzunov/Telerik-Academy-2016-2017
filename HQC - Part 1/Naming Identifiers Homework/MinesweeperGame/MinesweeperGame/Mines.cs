namespace MinesweeperGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Mines
    {
        private const int BoardRows = 5;
        private const int BoardColumns = 10;
        private const int InitialMinesCount = 15;
        private const int PoppedCellsToWin = 35;

        public static void Main()
        {
            IList<IList<ICell>> board = InitializeNewBoard(BoardRows, BoardColumns);

            var topScores = new List<IScore>();
            int row = 0;
            int column = 0;
            int popedCells = 0;
            bool isNewGame = true;
            bool hasWon = false;
            bool isDead = false;
            IPlayerCommand command;

            do
            {
                if (isNewGame)
                {
                    Console.WriteLine(GameMessages.StartGameMessage);
                    Console.WriteLine(GameMessages.CommandsMessage);

                    isNewGame = false;
                    DrawBoard(board);
                }

                command = ReadCommand();
                switch (command.Name)
                {
                    case Constants.ShowScoreboardCommand:
                        {
                            ShowScoreboard(topScores);
                            break;
                        }

                    case Constants.StartANewGameCommand:
                        {
                            isNewGame = true;
                            board = InitializeNewBoard(BoardRows, BoardColumns);
                            DrawBoard(board);
                            break;
                        }

                    case Constants.PopACellCommand:
                        {
                            row = int.Parse(command.Arguments[0]);
                            column = int.Parse(command.Arguments[1]);
                            board[row][column].Popped = true;

                            if (board[row][column].HasMine)
                            {
                                isDead = true;
                            }
                            else
                            {
                                int mines = GetHowManyMinesAround(board, row, column);
                                board[row][column].MinesAround = mines;
                                popedCells++;

                                hasWon = popedCells == PoppedCellsToWin;

                                DrawBoard(board);
                            }

                            break;
                        }

                    case Constants.ExitGameCommand:
                        {
                            Console.WriteLine(GameMessages.ExitMessage);
                            break;
                        }

                    default:
                        Console.WriteLine(GameMessages.WrongCommandMessage);
                        break;
                }

                if (hasWon || isDead)
                {
                    DrawBoard(board);
                    if (hasWon)
                    {
                        Console.WriteLine(GameMessages.WinnerMessage, popedCells);

                        IScore score = GetPlayerInfo(popedCells);
                        topScores.Add(score);
                        ShowScoreboard(topScores);
                    }
                    else
                    {
                        Console.Write(GameMessages.DeadMessage);
                        Console.Write("Your score {0}.", popedCells);

                        IScore score = GetPlayerInfo(popedCells);
                        SaveScore(topScores, score);
                        ShowScoreboard(topScores);
                    }

                    // Reset
                    board = InitializeNewBoard(BoardRows, BoardColumns);
                    hasWon = false;
                    isDead = false;
                    isNewGame = true;
                    popedCells = 0;
                }
            }
            while (command.Name != "exit");

            Console.WriteLine("Made in Bulgaria!");
            Console.Read();
        }

        private static IScore GetPlayerInfo(int points)
        {
            Console.Write("Enter your name:");
            string name = Console.ReadLine();

            var score = new Score(name, points);
            return score;
        }

        private static void SaveScore(List<IScore> topScores, IScore score)
        {
            if (topScores.Count < 5)
            {
                topScores.Add(score);
            }
            else
            {
                for (int i = 0; i < topScores.Count; i++)
                {
                    if (topScores[i].Points < score.Points)
                    {
                        topScores.Insert(i, score);
                        topScores.RemoveAt(topScores.Count - 1);
                        break;
                    }
                }
            }
        }

        private static IList<IList<ICell>> InitializeNewBoard(int rows, int columns)
        {
            var board = CreateBoard(rows, columns);
            SetMines(board);

            return board;
        }

        private static IPlayerCommand ReadCommand()
        {
            Console.Write("\nEnter a command: ");
            var input = Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var command = new PlayerCommand(input[0]);
            if (input.Length >= 3)
            {
                int row;
                int col;
                if (int.TryParse(input[1], out row) && int.TryParse(input[2].ToString(), out col))
                {
                    command.Arguments.Add(input[1]);
                    command.Arguments.Add(input[2]);
                }
            }

            return command;
        }

        private static void ShowScoreboard(List<IScore> topScores)
        {
            var scoresRankedByNameAndPoints = topScores.OrderBy(x => x.Points)
                .ThenBy(x => x.PlayerName).ToList();

            Console.WriteLine("\nPoints:");
            if (scoresRankedByNameAndPoints.Count > 0)
            {
                for (int i = 0; i < scoresRankedByNameAndPoints.Count; i++)
                {
                    int rank = i + 1;
                    Console.WriteLine(
                        Constants.ScorePrintFormat,
                        rank,
                        scoresRankedByNameAndPoints[i].PlayerName,
                        scoresRankedByNameAndPoints[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No players!");
            }
        }

        private static void DrawBoard(IList<IList<ICell>> board)
        {
            int rows = board.Count;
            int columns = board[0].Count;

            string columnsLineIndexator = "\n    ";
            for (int col = 0; col < columns; col++)
            {
                columnsLineIndexator += $"{col} ";
            }

            Console.WriteLine(columnsLineIndexator);
            Console.WriteLine("   " + new string('-', columns));
            for (int row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row);
                for (int col = 0; col < columns; col++)
                {
                    ICell cell = board[row][col];
                    string cellRepresentation;
                    if (cell.Popped && cell.HasMine)
                    {
                        cellRepresentation = Constants.CellWithMine;
                    }
                    else if (cell.Popped && !cell.HasMine)
                    {
                        cellRepresentation = cell.MinesAround.ToString();
                    }
                    else
                    {
                        cellRepresentation = Constants.UnpopedCell;
                    }

                    Console.Write(string.Format("{0} ", cellRepresentation));
                }

                Console.WriteLine("|");
            }

            Console.WriteLine("   " + new string('-', columns));
        }

        private static IList<IList<ICell>> CreateBoard(int boardRows, int boardColumns)
        {
            IList<IList<ICell>> board = new List<IList<ICell>>();
            for (int row = 0; row < boardRows; row++)
            {
                board.Add(new List<ICell>());
                for (int col = 0; col < boardColumns; col++)
                {
                    board[row].Add(new Cell());
                }
            }

            return board;
        }

        private static void SetMines(IList<IList<ICell>> board)
        {
            if (board == null)
            {
                throw new ArgumentNullException(nameof(board));
            }

            Random random = new Random();
            var minesCount = 0;
            int boardRows = board.Count;
            int boardColumns = board[0].Count;
            while (minesCount < InitialMinesCount)
            {
                int randomNumber = random.Next(boardRows * boardColumns);
                int row = randomNumber / boardColumns;
                int column = randomNumber % boardColumns;

                if (column == 0 && randomNumber != 0)
                {
                    row--;
                    column = boardColumns;
                }
                else
                {
                    column++;
                }

                if (!board[row][column - 1].HasMine)
                {
                    board[row][column - 1].HasMine = true;
                    minesCount++;
                }
            }
        }

        private static int GetHowManyMinesAround(IList<IList<ICell>> board, int row, int column)
        {
            int minesCount = 0;
            int rows = board.Count;
            int cols = board[0].Count;

            if ((row - 1 >= 0) && board[row - 1][column].HasMine)
            {
                minesCount++;
            }

            if ((row + 1 < rows) && board[row + 1][column].HasMine)
            {
                minesCount++;
            }

            if ((column - 1 >= 0) && board[row][column - 1].HasMine)
            {
                minesCount++;
            }

            if ((column + 1 < cols) && board[row][column + 1].HasMine)
            {
                minesCount++;
            }

            if ((row - 1 >= 0) && (column - 1 >= 0) && board[row - 1][column - 1].HasMine)
            {
                minesCount++;
            }

            if ((row - 1 >= 0) && (column + 1 < cols) && board[row - 1][column + 1].HasMine)
            {
                minesCount++;
            }

            if ((row + 1 < rows) && (column - 1 >= 0) && board[row + 1][column - 1].HasMine)
            {
                minesCount++;
            }

            if ((row + 1 < rows) && (column + 1 < cols) && board[row + 1][column + 1].HasMine)
            {
                minesCount++;
            }

            return minesCount;
        }
    }
}