using Gwynbleidd.GameProcess;
using Gwynbleidd.GameProcess.GameLogic;
using Gwynbleidd.Maze;
using Spectre.Console;
using System.Reflection.Metadata.Ecma335;

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
    public int CooldownModifier { get; protected set; }
    public bool CanMove { get; protected set; } = true;
    public bool HasCiri { get; protected set; }

    public bool Move() // returns true if there was movement an false if it wasn't
    {
        (int x, int y) originalPos = Position;
        MovementHelper.ActualizeDistances(Position, Velocity + VelocityModifier);
        ConsoleKeyInfo input;
        do
        {
            input = Console.ReadKey(true);
            (int dirX, int dirY) direction = MovementHelper.GetDirection(input);
            MovementHelper.ChangePosition(this, direction);

            // For testing only
            MazeMaster.DisplayMaze(); // This also needs to be improved, there is no reason for the character to do something with MazeMaster
        } while (input.Key != ConsoleKey.Enter); // Stop moving when pressing enter
        AnsiConsole.Clear();
        // Checks if there was actual movement
        return (originalPos == Position);
    }

    public void ModifyVelocity(int modifier)
        => VelocityModifier = modifier;
    public void ModifyCooldown(int modifier)
        => CooldownModifier = modifier;

    public void PlaceInMap((int x, int y) destination)
        => Position = destination;

    public abstract void UseSkill();
}