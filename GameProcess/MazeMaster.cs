using Gwynbleidd.Entities;
using Gwynbleidd.Entities.WildHunters;
using Gwynbleidd.Entities.Witchers;
using Gwynbleidd.GameProcess.GameLogic;
using Gwynbleidd.GameProcess.Menus;
using Gwynbleidd.Maze;
using Spectre.Console;

namespace Gwynbleidd.GameProcess;

public static class MazeMaster
{
    private static Board? Maze;
    public static Player RunMaze(Player p1, Player p2)
    {
        Maze = MazeGenerator.GenerateMaze(p1, p2)
            ?? throw new MazeGenerationException("Could not create a Maze. Please try again.");

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

    private static void GameLoop(Player p1, Player p2)
    {
        // First player turn
        foreach (var character in p1.Party)
        {
            // Manages the player movement for each character
            if (character.CanMove)
                PerformActions(character);
            // Actualices map to change squares atributtes (handling trap penalties, cooldown tracking, and turn-based effects)
            ActualizeMaze();
            //TODO
            // Shows current board state
            Maze!.PrintBoard();
        }

        // Second player turn
        foreach (var character in p2.Party)
        {
            // Manages the player movement for each character
            if (character.CanMove)
                PerformActions(character);
            // Actualices map to change squares atributtes (handling trap penalties, cooldown tracking, and turn-based effects)
            ActualizeMaze();
            //TODO
            // Shows current board state
            Maze!.PrintBoard();
        }
    }
    
    public static void PerformActions(Character character)
    {
        // It should show a menu with the current player and some image, for now just the name
        AnsiConsole.Write("Press 1 to move. Press 2 to use your skill");
        character.Move(Maze!); // sends maze to Move so that the character can be able to decide if a position is valid or not
    }

    public static void ActualizeMaze()
    {

    }
}

public class MazeGenerationException(string message) : Exception(message);