using Gwynbleidd.GameProcess.GameLogic;
using Gwynbleidd.Maze;

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
    public (int X, int Y) Position { get; set; }
    public int VelocityModifier { get; protected set; }
    public bool CanMove { get; private set; } = true;
    public bool HasCiri { get; protected set; }

    public bool Move(Board maze) // returns true if there was movement an false if it wasn't
    {
        int[,] distances = MovementHelper.GetDistances(Position, Velocity + VelocityModifier, maze);
        (int x, int y) originalPos = Position;
        ConsoleKeyInfo input;
        do
        {
            input = Console.ReadKey(true);
            string? direction = null;
            // Sends a direction to ChangePosition() method if the key is valid for movement
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    direction = "N";
                    break;
                case ConsoleKey.RightArrow:
                    direction = "E";
                    break;
                case ConsoleKey.LeftArrow:
                    direction = "W";
                    break;
                case ConsoleKey.DownArrow:
                    direction = "S";
                    break;
            }
            // If the player selected a direction via keyboard
            if (!string.IsNullOrEmpty(direction)) 
                ChangePosition(MovementHelper.Direction[direction], distances);

        } while (input.Key != ConsoleKey.Enter); // Stop moving when pressing enter

        if (originalPos == Position)
            return false; // there was no movement
        else
            return true;
    }

    public void ChangePosition((int x, int y) direction, int[,] distances)
    {
    }

    public abstract void UseSkill();
}