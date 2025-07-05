namespace Gwynbleidd.Maze;
public class BoardSquare
{
    public bool IsOccupied { get; set; }
    public bool IsFrozen { get; set; }
    public bool IsObstacle { get; set; }

    public BoardSquare(bool isOccupied = false, bool isFrozen = false, bool isObstacle = false)
    {
        IsOccupied = isOccupied;
        IsFrozen = isFrozen;
        IsObstacle = isObstacle;
    }
}
