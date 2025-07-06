using Gwynbleidd.Maze;
using Spectre.Console;

namespace Gwynbleidd.GameProcess.GameLogic;

public static class MovementHelper
{
    // Dictionary mapping names to direction
    public static readonly Dictionary<string, (int X, int Y)> Direction = new()
    {
        ["N"] = (0, -1),  // Up
        ["E"] = (1, 0),  // Right
        ["S"] = (0, 1),  // Down
        ["W"] = (-1, 0),  // Left
    };

    public static int[,] GetDistances((int row, int col)Position, int velocity,Board maze)
    {

        int mazeDim = maze.GetLength();
        // Standard BFS algorithm implementation to check for distances
        int[,] distances = new int[mazeDim, mazeDim];
        bool[,] visited = new bool[mazeDim, mazeDim];
        Queue<(int x, int y)> queue = new();

        // Initializes all squares as unreachable for the character
        for (int i = 0; i < mazeDim; i++)
            for (int j = 0; j < mazeDim; j++)
                distances[i, j] = -1;

        // Starts the BFS traversal
        distances[Position.row, Position.col] = 0;
        queue.Enqueue(Position);
        while (queue.Count > 0)
        {
            (int cX, int cY) = queue.Dequeue();

            if (distances[cX, cY] >= velocity) // skips all squares within the distance given in velocity 
                continue;

            foreach (var (X, Y) in Direction.Values)
            {
                // Visits all adjacent squares
                int neighborX = cX + X;
                int neighborY = cY + Y;

                // If the square is inside the Maze bounds,   
                if (InMazeBounds(neighborX, neighborY, mazeDim) 
                    && !visited[neighborX, neighborY] // hasn't been visited,
                    && !maze[neighborX, neighborY].IsObstacle // there are no obstacles on it,
                    && !maze[neighborX, neighborY].IsOccupied) // and there is no other character on top,
                {
                    distances[neighborX, neighborY] = distances[cX, cY] + 1; // actualize the distance
                    visited[neighborX, neighborY] = true;
                    queue.Enqueue((neighborX, neighborY));
                }
            }
        }
        return distances;
    }

    public static bool InMazeBounds(int x, int y, int mazeDim)
        => x >= 0 && x < mazeDim && y >= 0 && y < mazeDim;

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
}
