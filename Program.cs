namespace Gwynbleidd;

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
            AnsiConsole.Clear();
            AnsiConsole.Write(new Markup("[red]Congratulations Witcher![/]"));
        }
        else
        {
            // TODO show thanks for playing and clean the las console line
        }
    }
}