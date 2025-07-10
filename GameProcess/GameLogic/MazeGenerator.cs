using Gwynbleidd.Entities;
using Gwynbleidd.Maze;

namespace Gwynbleidd.GameProcess.GameLogic;
public static class MazeGenerator
{
    private readonly static int MazeDimension = 10;
    // For now it will only generate a maze with just free squares
    public static Board GenerateMaze(Player p1, Player p2)
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
        PlaceCharacters(p1, p2, maze);
        return maze;
    }

    public static void PlaceCharacters(Player p1, Player p2, Board maze)
    {
        Random rand = new();

        foreach (var character in p1.Party)
        {
            int x = rand.Next(0, 9);
            int y = rand.Next(0, 9);
            maze[x, y].IsOccupied = true;
            character.PlaceInMap((x, y));
        }

        foreach (var character in p2.Party)
        {
            int x = rand.Next(0, 9);
            int y = rand.Next(0, 9);
            maze[x, y].IsOccupied = true;
            character.PlaceInMap((x, y));
        }
    }
}
