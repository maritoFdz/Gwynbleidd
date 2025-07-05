namespace Gwynbleidd.Board;

using Gwynbleidd.Maze.Squares;
public class Board
{
    public BoardSquare[,] Cells { get; private set; }
    public Board(int dimension)
    {
        if (dimension < 1)
            throw new ArgumentException("Width and height must be at least 1.");
        Cells = new BoardSquare[dimension, dimension];
    }

    public void PrintBoard()
    {
        for (int i = 0; i < Cells.GetLength(0); i++)
        {
            for (int j = 0; j < Cells.GetLength(0); j++)
                Console.Write(Cells[i, j].IsOccupied ? "*" : "+");
            Console.WriteLine();
        }
    }
}
