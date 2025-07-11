namespace Gwynbleidd.Maze;
public class BoardSquare
{
    public bool IsOccupied { get; set; }
    public bool IsFrozen { get; set; } // TODO
    public bool IsObstacle { get; set; }
    public bool HasPotion { get; set; }
}
