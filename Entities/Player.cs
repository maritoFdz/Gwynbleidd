namespace Gwynbleidd.Entities;

public class Player(string name, Character[] members)
{
    public readonly string Name = name;
    public readonly Character[] Party = members;
}