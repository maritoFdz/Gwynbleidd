using Gwynbleidd.GameProcess;
using Gwynbleidd.GameProcess.GameLogic;
using Spectre.Console;
using System.Globalization;

namespace Gwynbleidd.Entities;

public abstract class Character(
    string name,
    string description,
    char appareance,
    int velocity,
    int skillCooldown) : IPlayable
{
    public string Name { get; protected set; } = name;
    public string Description { get; protected set; } = description;
    public int Velocity { get; protected set; } = velocity;
    public int Cooldown { get; protected set; } = skillCooldown;
    public char Appareance { get; protected set; } = appareance;
    public (int X, int Y) Position { get; protected set; }
    public int VelocityModifier { get; protected set; }
    public int CooldownModifier { get; protected set; }
    public bool CanMove { get; protected set; } = true;

    public abstract bool Move();

    public abstract void UseSkill();

    public void ModifyStats(int vMod, int cMod) // for convention, a 0 - 0 modifier implies a stats reset
   => (VelocityModifier, CooldownModifier) = (vMod == 0 & cMod == 0) ? (0, 0) : (VelocityModifier + vMod, CooldownModifier + cMod);

    public void PlaceInMap((int x, int y) destination)
        => Position = destination;
}