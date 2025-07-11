using Gwynbleidd.Entities;

namespace Gwynbleidd.Maze;

// TODO this class should be improved a lot
public class BoardSquare
{
    public Character? CharacterOnTop { get; set; } // this could be a CharacteronTop atribute or smth like that, it would be eassier to trigger modifiers
    public bool IsFrozen { get; set; } // TODO
    public bool IsObstacle { get; set; }
    public Potion? PotionOnTop { get; set; }
}
