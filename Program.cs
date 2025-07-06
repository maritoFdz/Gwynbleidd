namespace Gwynbleidd;

using Gwynbleidd.Entities;
using Gwynbleidd.Entities.WildHunters;
using Gwynbleidd.Entities.Witchers;
using Gwynbleidd.GameProcess;
using Gwynbleidd.GameProcess.GameLogic;
using Gwynbleidd.GameProcess.Menus;
using Gwynbleidd.Maze;
using Spectre.Console;
using System.Xml.Schema;

public class GwynbleiddGame
{
    public static void Main()
    {
        // Displays main menu with Play/Exit
        MainMenu.Display();
        if (MainMenu.GetUserSelection())
        {
            // Creates players
            string? p1Name;
            do
            {
                AnsiConsole.Write("Type Player 1 name: ");
                p1Name = Console.ReadLine();
                AnsiConsole.Clear();
            } while (string.IsNullOrWhiteSpace(p1Name));

            string? p2Name;
            do
            {
                AnsiConsole.Write("Type Player 2 name: ");
                p2Name = Console.ReadLine();
                AnsiConsole.Clear();
            } while (string.IsNullOrWhiteSpace(p2Name));


            CSelectionMenu.Display(); // TODO Implement two menus, one for the Wild Hunt and the other for the Witchers, with diff decoration

            // For now, we will simplfy this by creating a 1vs1 match
            var p1Team = new[] { new Geralt() };
            var p2Team = new[] { new Eredin() };

            Player p1 = new(p1Name, p1Team);
            Player p2 = new(p2Name, p2Team);
            MazeMaster.StartGame(p1, p2);
        }
        else
        {
            // TODO show thanks for playing and clean the las console line
        }
    }
}