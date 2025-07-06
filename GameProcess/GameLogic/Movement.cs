using Gwynbleidd.Maze;

namespace Gwynbleidd.GameProcess.GameLogic;

public static class MovementHelper
{
    // Dictionary mapping names to direction
    public static readonly Dictionary<string, (int X, int Y)> Direction = new()
    {
        ["N"] = (0, -1),  // Up
        ["NE"] = (1, -1),  // Diagonal Up-Right
        ["E"] = (1, 0),  // Right
        ["SE"] = (1, 1),  // Diagonal Down-Right
        ["S"] = (0, 1),  // Down
        ["SW"] = (-1, 1),  // Diagonal Down-Left
        ["W"] = (-1, 0),  // Left
        ["NW"] = (-1, -1)   // Diagonal Up-Right
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

                // If the square hasn't been visited, there is no other character on top, there are no obstacles and it is inside the Maze bounds
                if (!visited[neighborX, neighborY] && !maze[neighborX, neighborY].IsObstacle && InMazeBounds(neighborX, neighborY, mazeDim))
                {
                    distances[neighborX, neighborY] = distances[cX, cY] + 1; // then actualize the distance
                    visited[neighborX, neighborY] = true;
                    queue.Enqueue((neighborX, neighborY));
                }
            }
        }
        return distances;
    }

    private static bool InMazeBounds(int x, int y, int mazeDim)
        => x >= 0 && x < mazeDim && y >= 0 && y < mazeDim;
}
