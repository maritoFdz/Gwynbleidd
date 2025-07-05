namespace Gwynbleidd.Maze.Obstacles;
public abstract class Trap : BoardSquare
{
    private const bool isObstacle = true;
    private const bool isFrozen = false;
    private const bool isOccupied = false;

    public Trap() : base(isOccupied, isFrozen, isObstacle) { }

    public abstract void TriggerTrap();
}
