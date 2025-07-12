namespace Gwynbleidd.Entities.Playable.Witchers;

public class Geralt : Witcher
{
    private const string name = "Geralt of Rivia";
    private const string description = "The world doesn't need a hero. It needs a professional.";
    private const string appareance = "+";
    private const int velocity = 3;
    private const int coolDown = 2;


    public Geralt() : base(name, description, appareance, velocity, coolDown) { }

    public override void UseSkill()
    {
        // TODO WHEN BOARD IS IMPLEMENTED
        // Use skill logic for Geralt
    }
}
