using Gwynbleidd.Entities.Playable;
using Gwynbleidd.GameProcess;

namespace Gwynbleidd.Entities.Maze_Entitites;

public class Portal() : IEntity
{
    public char Appareance { get; private set; } = '@';
    public (int X, int Y) Position;
    public Portal? Exit { get; private set; }

    public void SetExit(Portal exit)
        => Exit = exit;
    public void Teleport(IPlayable character)
    {
        character.PlaceInMap(Exit!.Position);
    }
}