namespace Gwynbleidd.Entities;

public abstract class Character(
    string name,
    string description,
    int velocity,
    int skillCooldown)
{
    public readonly string Name = name;
    public readonly string Description = description;
    public readonly int Velocity = velocity;
    public readonly int SkillCooldown = skillCooldown;
    public (int X, int Y) Position { get; protected set; }
    public int VelocityModifier { get; protected set; }
    public bool CantMove { get; protected set; }
    public bool HasCiri { get; protected set; }

    public void Move(int direction)
    {
        int realVelocity = Velocity + VelocityModifier;
        // TODO WHEN BOARD IS IMPLEMENTED
    }

    public abstract void UseSkill();
}