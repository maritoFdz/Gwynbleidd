using Gwynbleidd.Entities.Playable;

namespace Gwynbleidd.GameProcess.GameLogic;

public interface IModifier
{
    String Name { get; }
    int RemainingTurns { get; }
    Character? Target { get; }
    int VelocityModifier { get; }
    int CooldownModifier { get; }

    void SetTarget(Character? target);
    void Apply();
    void Update();
}
