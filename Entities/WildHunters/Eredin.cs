namespace Gwynbleidd.Entities.WildHunters;

public class Eredin : WildHunter
{
    private const string name = "Eredin";
    private const string description = "A high ranking general in his world until he killed the king and became his successor.";
    private const char appareance = '*';
    private const int velocity = 2;
    private const int skillCooldown = 3;

    public Eredin() : base(name, description, appareance, velocity, skillCooldown) { }

    public override void UseSkill()
    {
        // TODO WHEN BOARD IS IMPLEMENTED
        // Use skill logic for Eredin
    }
}
