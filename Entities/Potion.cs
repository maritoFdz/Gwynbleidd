using Gwynbleidd.GameProcess.GameLogic;

namespace Gwynbleidd.Entities;

public class Potion(string name, int amountOfTurns, int vMod, int cMod) : IModifier
{
    public string Name { get; protected set; } = name;
    public int RemainingTurns { get; private set; } = amountOfTurns;
    public Character? Target { get; private set; } = null;
    public int VelocityModifier { get; private set; } = vMod;
    public int CooldownModifier { get; private set; } = cMod;
    public (int X, int Y) Position { get; private set; }
    public string? Appareance { get; private set; }


    public void OnTurnEnd()
    {
        // If no players have trigger it or it expired
        if (RemainingTurns == 0 && Target != null)
            Remove();
        else
            RemainingTurns--;
    }

    public void Apply() // Change character atributes
    {
        Target!.ModifyCooldown(CooldownModifier);
        Target!.ModifyVelocity(VelocityModifier);
    }

    public void Remove() // Maybe instead of creating new items, a fixed amount could exist and items could change (????)
    {
        Target!.ModifyCooldown(0);
        Target!.ModifyVelocity(0);
        Target = null;
    }

}
