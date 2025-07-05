namespace Gwynbleidd.Maze.Squares;
public class BoardSquare
{
    public bool IsOccupied { get; protected set; }
    public bool IsFrozen { get; protected set; }
    public bool IsObstacle { get; protected set; }

    public BoardSquare(bool isOccupied = false, bool isFrozen = false, bool isObstacle = false)
    {
        IsOccupied = isOccupied;
        IsFrozen = isFrozen;
        IsObstacle = isObstacle;
    }
}
