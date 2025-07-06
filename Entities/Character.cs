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
        (int x, int y) originalPos = Position;
        ConsoleKeyInfo input;
        do
        {
            input = Console.ReadKey(true);
            
            // Sends a direction to ChangePosition() method if the key is valid for movement
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    ChangePosition(MovementHelper.Direction["N"], maze);
                    break;
                case ConsoleKey.RightArrow:
                    ChangePosition(MovementHelper.Direction["E"], maze);
                    break;
                case ConsoleKey.LeftArrow:
                    ChangePosition(MovementHelper.Direction["W"], maze);
                    break;
                case ConsoleKey.DownArrow:
                    ChangePosition(MovementHelper.Direction["S"], maze);
                    break;
            }
        } while (input.Key != ConsoleKey.Enter); // Stop moving when pressing enter

        if (originalPos == Position)
            return false; // there was no movement
        else
            return true;
    }

    public void ChangePosition((int x, int y) direction, Board maze)
    {
        if (MovementHelper.IsReachablePosition(direction, maze))
            Console.WriteLine("Reachable");
    }

    public abstract void UseSkill();
}