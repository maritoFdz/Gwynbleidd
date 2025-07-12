using Gwynbleidd.Entities.Playable;
using Gwynbleidd.GameProcess;

namespace Gwynbleidd.Entities.Maze_Entitites;

public class Portal() : IEntity
{
    public string Appareance { get; private set; } = "@";
    public (int X, int Y) Position;
    public Portal? Exit { get; private set; }

    public void PlaceInMap((int x, int y) destination)
        => Position = destination;
    public void SetExit(Portal exit)
        => Exit = exit;
}