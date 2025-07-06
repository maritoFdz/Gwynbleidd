namespace Gwynbleidd.Entities.Witchers;

public class Geralt : Character
{
    private const string name = "Geralt of Rivia";
    private const string description = "The world doesn't need a hero. It needs a professional.";
    private const int velocity = 3;
    private const int coolDoown = 2;

    public Geralt() : base(name, description, velocity, coolDoown) { }

    public override void UseSkill()
    {
        // TODO WHEN BOARD IS IMPLEMENTED
        // Use skill logic for Geralt
    }
}
