using Gwynbleidd.Entities;

namespace Gwynbleidd.Maze;

// TODO this class should be improved a lot
public class BoardSquare
{
    public IPlayable? CharacterOnTop { get; private set; } = null;
    public IEntity? Content { get; private set; } = null;
    public bool IsFrozen { get; private set; } = false; // TODO
    public bool IsObstacle { get; private set; } = false;

    public void SetCharacter(IPlayable? character)
        => CharacterOnTop = character;

    public void SetContent(IEntity? content)
        => Content = content;
}
