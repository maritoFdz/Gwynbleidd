using Gwynbleidd.GameProcess.GameLogic;

namespace Gwynbleidd.Entities;

public class Item(string name, int amountOfTurns, int vMod, int cMod) : IModifier
{
    public string Name { get; private set; } = name;
    public int RemainingTurns { get; private set; } = amountOfTurns;
    public Character? Target { get; private set; } = null;
    public (int X, int Y) Position { get; private set; }
    public int VelocityModifier { get; private set; } = vMod;
    public int CooldownModifier { get; private set; } = cMod;


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
        Target = null;
    }

}
