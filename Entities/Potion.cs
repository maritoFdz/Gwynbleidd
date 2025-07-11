using Gwynbleidd.GameProcess.GameLogic;

namespace Gwynbleidd.Entities;

// TODO Potions to implement in some moment 
// White honey to end with all modifiers targeting the player
// Wolve Hour to move the player randomly but give him instant cooldown
public class Potion(string name, int amountOfTurns, int vMod, int cMod) : IModifier, IEntity
{
    public string Name { get; protected set; } = name;
    public int RemainingTurns { get; private set; } = amountOfTurns;
    public Character? Target { get; private set; } = null;
    public int VelocityModifier { get; private set; } = vMod;
    public int CooldownModifier { get; private set; } = cMod;
    public char Appareance { get; private set; } = 'P';

    public void SetTarget(Character? target)
        => this.Target = target;

    public void Apply() // Change character atributes
        => Target!.ModifyStats(VelocityModifier, CooldownModifier);

    public void Update()
        => RemainingTurns--;
}
