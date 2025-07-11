using Gwynbleidd.Entities;
using Gwynbleidd.Maze;
using Spectre.Console;
using static System.Net.Mime.MediaTypeNames;

namespace Gwynbleidd.GameProcess.GameLogic;

public static class MovementHelper
{
    private static Board? Maze;
    private static int[,]? CurrentCharacterDistances;

    // Dictionary mapping names to direction
    public static readonly Dictionary<string, (int X, int Y)> Direction = new()
    {
        ["N"] = (-1, 0),  // Up
        ["E"] = (0, 1),  // Right
        ["S"] = (1, 0),  // Down
        ["W"] = (0, -1),  // Left
    };

    public static void AddMazeToHelper(Board maze)
    { 
        Maze = maze;
        CurrentCharacterDistances = new int[Maze.GetLength(), Maze.GetLength()];
    }

    public static void ActualizeDistances((int row, int col)Position, int velocity)
    {
        int mazeDim = Maze!.GetLength();
        bool[,] visited = new bool[mazeDim, mazeDim];
        Queue<(int x, int y)> queue = new();

        // Initializes all squares as unreachable for the character
        for (int i = 0; i < mazeDim; i++)
            for (int j = 0; j < mazeDim; j++)
                CurrentCharacterDistances![i, j] = -1;

        // Starts the BFS traversal
        CurrentCharacterDistances![Position.row, Position.col] = 0;
        queue.Enqueue(Position);
        while (queue.Count > 0)
        {
            (int cX, int cY) = queue.Dequeue();

            if (CurrentCharacterDistances[cX, cY] >= velocity) // skips all squares within the distance given in velocity 
                continue;

            foreach (var (X, Y) in Direction.Values)
            {
                // Visits all adjacent squares
                int neighborX = cX + X;
                int neighborY = cY + Y;

                // If the square is inside the Maze bounds,   
                if (InMazeBounds(neighborX, neighborY) 
                    && !visited[neighborX, neighborY] // hasn't been visited,
                    && !Maze[neighborX, neighborY].IsObstacle // there are no obstacles on it,
                    && Maze[neighborX, neighborY].CharacterOnTop == null) // and there is no other character on top,
                {
                    CurrentCharacterDistances[neighborX, neighborY] = CurrentCharacterDistances[cX, cY] + 1; // actualize the distance
                    visited[neighborX, neighborY] = true;
                    queue.Enqueue((neighborX, neighborY));
                }
            }
        }
    }

    public static void ChangePosition(Character character, (int x, int y) direction)
    {
        (int nextX, int nextY) = (character.Position.X + direction.x, character.Position.Y + direction.y);
        if (InMazeBounds(nextX, nextY) && CurrentCharacterDistances![nextX, nextY] != -1)
        {
            Maze![character.Position.X, character.Position.Y].CharacterOnTop = null;
            character.PlaceInMap((nextX, nextY));
            Maze![nextX, nextY].CharacterOnTop = character;
        }
    }

    public static (int x, int y) GetDirection(ConsoleKeyInfo input)
    {
        string? direction = null;
        (int dirX, int dirY) = (0, 0);
        // Sends a direction to ChangePosition() method if the key is valid for movement
        switch (input.Key)
        {
            case ConsoleKey.UpArrow:
                direction = "N";
                break;
            case ConsoleKey.RightArrow:
                direction = "E";
                break;
            case ConsoleKey.LeftArrow:
                direction = "W";
                break;
            case ConsoleKey.DownArrow:
                direction = "S";
                break;
        }
        if (!string.IsNullOrEmpty(direction))
            (dirX, dirY) = Direction[direction];

        // If the player selected a direction via keyboard
        return (dirX, dirY);
    }

    public static bool InMazeBounds(int x, int y)
    => x >= 0 && x < Maze!.GetLength() && y >= 0 && y < Maze.GetLength();
}
