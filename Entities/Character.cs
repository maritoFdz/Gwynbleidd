namespace Gwynbleidd.Entities;

public abstract class Character
{
    public readonly int Velocity;
    public readonly int SkillCooldown;
    public int VelocityModifier { get; protected set; }
    public bool CantMove { get; protected set; }
    public bool HasCiri { get; protected set; }

    public Character(int velocity, int SkillCooldown)
    {
        this.Velocity = velocity;
        this.SkillCooldown = SkillCooldown;
    }

    public void Move(int direction)
    {
        int realVelocity = Velocity + VelocityModifier;
        // TODO WHEN BOARD IS IMPLEMENTED
    }

    public abstract void UseSkill();
}