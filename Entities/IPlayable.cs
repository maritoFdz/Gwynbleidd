namespace Gwynbleidd.Entities;
public interface IPlayable : IEntity
{
    public string Description { get; }
    public int Velocity { get; }  // How many squares can move per turn
    public int Cooldown { get; }

    public void PlaceInMap((int x, int y) destination);
    public bool Move();
    public void UseSkill();
    public void ModifyStats(int vMod, int cMod);
}