using Spectre.Console;

namespace Gwynbleidd.GameProcess.Menus;

public static class MainMenu
{
    public static void Display()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();
        // Title
        AnsiConsole.Write(new FigletText("Gwynbleidd")
            .Centered()
            .Color(Color.Navy));
        // Selection
        AnsiConsole.Write(new Text("1. Play\n2. Exit")
            .Centered());
        AnsiConsole.Cursor.MoveDown(); // This avoids that a null input could erase the "2. Exit" line
        AnsiConsole.Cursor.MoveRight();
        AnsiConsole.Cursor.Hide();
    }

    public static bool GetUserSelection()
    {
        while (true)
        {
            try
            {
                string? input = Console.ReadLine();
                AnsiConsole.Cursor.MoveUp(1);
                MainMenu.CleanSelection();
                if (string.IsNullOrWhiteSpace(input))
                    continue;
                int option = int.Parse(input);
                if (option == 1 || option == 2)
                {
                    AnsiConsole.Clear(); // Cleans the tittle
                    return (option == 1);
                }
            }
            catch (FormatException) { continue; }
        }
    }
    
    public static void CleanSelection()
    {
        // Move cursor to the beginning of the current line
        AnsiConsole.Cursor.MoveLeft(AnsiConsole.Console.Profile.Width);
        // Clear the current line
        AnsiConsole.Write("\x1B[2K");
    }
}