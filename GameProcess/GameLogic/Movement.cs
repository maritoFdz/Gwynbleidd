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

    public static bool IsReachablePosition((int x, int y) position, Board maze)
    {
        return false;
    }
}
