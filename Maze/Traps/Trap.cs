namespace Gwynbleidd.Maze.Traps;
public abstract class Trap : BoardSquare
{
    public Trap() : base() { }

    public abstract void TriggerTrap();
}
