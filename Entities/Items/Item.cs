using Gwynbleidd.GameProcess.GameLogic;

namespace Gwynbleidd.Entities.Items;

public abstract class Item : IModifier
{
    public Character? Target { get; private set; }
    public int RemainingTurns { get; private set; }

    public abstract void Apply();
    public abstract void OnTurnEnd();
    public abstract void Remove();
}
