using Gwynbleidd.Entities;
using Gwynbleidd.Maze;
using System;
using System.Text;

namespace Gwynbleidd.GameProcess.GameLogic;
public static class MazeGenerator
{
    private readonly static int MazeDimension = 20;
    // For now it will only generate a maze with just free squares
    public static Board GenerateMaze(Player p1, Player p2)
    {
        Board maze = new(MazeDimension);
        PlaceCharacters(p1, p2, maze);
        PlaceItems(maze);
        return maze;
    }

    public static void PlaceCharacters(Player p1, Player p2, Board maze)
    {

        foreach (var character in p1.Party)
        {
            PlaceRandom(character, maze);
        }

        foreach (var character in p2.Party)
        {
            PlaceRandom(character, maze);
        }
    }

    // For now it will have a fixed amount of items
    public static void PlaceItems(Board maze)
    {
        const int amount = 8;

        for (int i = 0; i < amount; i++)
        {
            var potion = PotionGenerator.Generate();
            PlaceRandom(potion, maze);
        }
    }

    public static void PlaceRandom(IEntity entity, Board maze)
    {
        int x = Random.Shared.Next(maze.GetLength());
        int y = Random.Shared.Next(maze.GetLength());

        if (entity is IPlayable playable)
        {
            playable.PlaceInMap((x, y));
            maze[x, y].SetCharacter(playable);
        }
        else
        {
            maze[x, y].SetContent(entity);
        }
    }
}
