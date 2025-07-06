namespace Gwynbleidd.Maze.Obstacles;
public abstract class Trap : BoardSquare
{
    public Trap() : base() { }

    public abstract void TriggerTrap();
}
