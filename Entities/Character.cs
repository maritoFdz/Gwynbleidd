namespace Gwynbleidd.Entities;

public abstract class Character
{
    public readonly String Name;
    public readonly String Description;
    public readonly int Velocity;
    public readonly int SkillCooldown;
    public (int X, int Y) Position { get; protected set; }
    public int VelocityModifier { get; protected set; }
    public bool CantMove { get; protected set; }
    public bool HasCiri { get; protected set; }

    public Character(String name, String description, int velocity, int skillCooldown)
    {
        Name = name;
        Description = description;
        this.Velocity = velocity;
        this.SkillCooldown = skillCooldown;
    }

    public void Move(int direction)
    {
        int realVelocity = Velocity + VelocityModifier;
        // TODO WHEN BOARD IS IMPLEMENTED
    }

    public abstract void UseSkill();
}