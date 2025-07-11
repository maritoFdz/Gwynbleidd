using Spectre.Console;
using System.Runtime.CompilerServices;

namespace Gwynbleidd.Maze;
public class Board
{
    public BoardSquare[,] Cells { get; private set; }

    public Board(int dimension)
    {
        if (dimension < 1)
            throw new ArgumentException("Width and height must be at least 1.");
        Cells = new BoardSquare[dimension, dimension];
        for (int i = 0; i < Cells.GetLength(0); i++)
        {
            for (int j = 0; j < Cells.GetLength(0); j++)
            {
                Cells[i, j] = new BoardSquare();
            }
        }
    }

    public BoardSquare this[int x, int y]
    { get => Cells[x, y]; }

    public int GetLength() => Cells.GetLength(0);

    public void PrintBoard()
    {
        var grid = new Grid();
        for (int i = 0; i < Cells.GetLength(1); i++)
            grid.AddColumn();

        for (int row = 0; row < Cells.GetLength(0); row++)
        {
            var rowContent = new List<string>(Cells.GetLength(1));
            for (int col = 0; col < Cells.GetLength(1); col++)
                rowContent.Add(Cells[row, col].CharacterOnTop != null ? "+" : Cells[row, col].Content != null ? "P" : ".");
            grid.AddRow(rowContent.ToArray());
        }
        AnsiConsole.Write(grid);
    }
}
