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

    public bool Move(Board maze) // returns true if there was movement an false if it wasn't
    {
        // TODO (somehow make that maze doesn't have to go to the player class)
        int[,] distances = MovementHelper.GetDistances(Position, Velocity + VelocityModifier, maze);
        (int x, int y) originalPos = Position;
        ConsoleKeyInfo input;
        do
        {
            input = Console.ReadKey(true);
            (int dirX, int dirY) direction = MovementHelper.GetDirection(input);
            ChangePosition(direction, distances, maze);

            // For testing only
            AnsiConsole.Clear();
            maze.PrintBoard();
        } while (input.Key != ConsoleKey.Enter); // Stop moving when pressing enter

        AnsiConsole.Clear();

        // Checks if there was actual movement
        if (originalPos == Position)
            return false;
        else
            return true;
    }

    public void ChangePosition((int x, int y) direction, int[,] distances,Board maze)
    {
        (int nextX, int nextY) = (Position.X + direction.y, Position.Y + direction.x);
        if (MovementHelper.InMazeBounds(nextX, nextY, maze.GetLength()) && distances[nextX, nextY] != -1)
        {
            maze[Position.X, Position.Y].IsOccupied = false;
            Position = (nextX, nextY);
            maze[Position.X, Position.Y].IsOccupied = true;
        }
    }

    public void ModifyVelocity(int modifier)
        => VelocityModifier = modifier;
    public void ModifyCooldown(int modifier)
    => CooldownModifier = modifier;

    public abstract void UseSkill();
}