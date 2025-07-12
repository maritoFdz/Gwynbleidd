using Gwynbleidd.Entities.Playable;
using Gwynbleidd.GameProcess;
using Gwynbleidd.GameProcess.GameLogic;
using Spectre.Console;

namespace Gwynbleidd.Entities.Playable.WildHunters;
public abstract class WildHunter(string name, string description, string appareance, int velocity, int skillCooldown)
    : Character(name, description, appareance, velocity, skillCooldown)
{

    // TODO freeze path
    public override bool Move() // returns true if there was movement an false if it wasn't
    {
        (int x, int y) originalPos = Position;
        MovementHelper.ActualizeDistances(Position, Velocity + VelocityModifier);
        ConsoleKeyInfo input;
        bool teleported;
        do
        {
            input = Console.ReadKey(true);
            (int dirX, int dirY) direction = MovementHelper.GetDirection(input);
            MovementHelper.ChangePosition(this, direction);
            teleported = MovementHelper.SteppedOnPortal(Position);

            // For testing only
            MazeMaster.DisplayMaze(); // This also needs to be improved, there is no reason for the character to do something with MazeMaster
        } while (input.Key != ConsoleKey.Enter && !MovementHelper.GrabbedPotion() || teleported); // Stop moving when pressing enter or getting an item
        AnsiConsole.Clear();
        // Checks if there was actual movement
        return originalPos == Position;
    }

    public abstract override void UseSkill();
}
