using Gwynbleidd.Entities;
using Gwynbleidd.Entities.Playable;
using Gwynbleidd.GameProcess.GameLogic;
using Gwynbleidd.Maze;
using Spectre.Console;
using System.Data;

namespace Gwynbleidd.GameProcess;

public static class MazeMaster
{
    private static Board? Maze;

    public static Player RunMaze(Player p1, Player p2)
    {
        Maze = MazeGenerator.GenerateMaze(p1, p2)
            ?? throw new MazeGenerationException("Could not create a Maze. Please try again.");
        MovementHelper.AddMazeToHelper(Maze);

        // Selects the starter player randomly
        Player firstP = new Random().Next(2) == 0 ? p1 : p2;
        Player secP = firstP == p1 ? p2 : p1;

        // Enters into the game loop until win condition
        while (!(firstP.IsWinner || secP.IsWinner))
        {
            GameLoop(firstP, secP);
        }
        return firstP.IsWinner ? firstP : secP;
    }

    public static void DisplayMaze()
    {
        AnsiConsole.Clear();
        Maze!.PrintBoard();
    }

    private static void GameLoop(Player p1, Player p2)
    {
        ModifiersManagment.Apply(); // modifies velocity and cooldown time for all characters

        // First player turn
        foreach (var character in p1.Party)
        {
            // Manages the player movement for each character
            if (character.CanMove)
                PerformActions(character);

            // TODO Actualices map to change squares atributtes (handling trap penalties, cooldown tracking, and turn-based effects)
        }

        // Second player turn
        foreach (var character in p2.Party)
        {
            // Manages the player movement for each character
            if (character.CanMove)
                PerformActions(character);

            // TODO Actualices map to change squares atributtes (handling trap penalties, cooldown tracking, and turn-based effects)
        }

        ModifiersManagment.OnTurnEnd();

        // testing
        if (ModifiersManagment.ActiveModifiers.Count > 0)
        {
            var modifierNames = ModifiersManagment.ActiveModifiers
                .Select(potion => potion.Name)
                .ToList();

            AnsiConsole.MarkupLine(string.Join(", ", modifierNames));
        }
        else
        {
            AnsiConsole.MarkupLine("[grey]No active modifiers[/]");
        }
        Console.ReadLine();
    }
    
    public static void PerformActions(Character character)
    {
        // It should show a menu with the current player and some image, for now just the name
        AnsiConsole.Write("Press 1 to move. Press 2 to use your skill");
        while(character.Move()) // sends maze to Move so that the character can be able to decide if a position is valid or not
        {
            Maze!.PrintBoard();
        }
    }

}

public class MazeGenerationException(string message) : Exception(message);