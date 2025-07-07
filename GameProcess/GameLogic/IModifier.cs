using Gwynbleidd.Entities;

namespace Gwynbleidd.GameProcess.GameLogic;
public interface IModifier
{
    int RemainingTurns { get; }
    Character? Target { get; }

    void Apply();
    void OnTurnEnd();
    void Remove();
}
