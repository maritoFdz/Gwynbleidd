using Gwynbleidd.Entities;
using Gwynbleidd.Maze;
using Spectre.Console;

namespace Gwynbleidd.GameProcess.GameLogic;
public static class MazeGenerator
{
    private readonly static int MazeDimension = 20;
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
                    IsObstacle = false,
                    HasPotion = false
                };
            }
        }
        PlaceCharacters(p1, p2, maze);
        PlaceItems(maze);
        return maze;
    }

    public static void PlaceCharacters(Player p1, Player p2, Board maze)
    {
        Random rand = new();

        foreach (var character in p1.Party)
        {
            int x = rand.Next(maze.GetLength());
            int y = rand.Next(maze.GetLength());
            maze[x, y].IsOccupied = true;
            character.PlaceInMap((x, y));
        }

        foreach (var character in p2.Party)
        {
            int x = rand.Next(maze.GetLength());
            int y = rand.Next(maze.GetLength());
            maze[x, y].IsOccupied = true;
            character.PlaceInMap((x, y));
        }
    }

    // For now it will have a fixed amount of items
    public static void PlaceItems(Board maze)
    {
        const int amount = 8;
        Random rand = new();
        var potions = new List<Potion>();

        for (int i = 0; i < amount; i++)
            potions.Add(PotionGenerator.Generate());

        foreach (var potion in potions)
        {
            int x = rand.Next(maze.GetLength());
            int y = rand.Next(maze.GetLength());
            maze[x, y].HasPotion = true;
            potion.PlaceInMap((x, y));
        }
    }
}
