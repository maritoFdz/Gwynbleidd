namespace Gwynbleidd.Entities;

public class Player(string name, Character[] members)
{
    public string Name { get; } = name;
    public Character[] Party { get; } = members;
}