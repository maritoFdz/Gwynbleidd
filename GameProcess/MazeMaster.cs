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
    public static void StartGame(Player p1, Player p2)
    {
        Maze = MazeGenerator.GenerateMaze(p1, p2);
    }
}