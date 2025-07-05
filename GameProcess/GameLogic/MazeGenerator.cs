using Gwynbleidd.Maze;

namespace Gwynbleidd.GameProcess.GameLogic;
public static class MazeGenerator
{
    private readonly static int MazeDimension = 10;
    // For now it will only generate a maze with just free squares
    public static Board GenerateMaze()
    {
        Board maze = new(MazeDimension);
        for (int i = 0; i < MazeDimension; i++)
        {
            for (int j = 0; j < MazeDimension; j++)
            {
                maze.Cells[i, j] = new BoardSquare
                {
                    IsFrozen = false,
                    IsOccupied = false,
                    IsObstacle = false
                };
            }
        }
        return maze;
    }
}
