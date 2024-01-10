using System.Timers;
using Timer = System.Timers.Timer;

namespace Pong;

internal static class Pong
{
    static void Main()
    {
        StartMenu();
        StartGame();

        //change to simply exiting after
        Console.WriteLine("PROGRAM END");
        Thread.Sleep(-1);

        //look a fidget spinner ߷
    }

    static void StartMenu()
    {
        Display.Menu.MenuLoop();
    }

    static void StartGame()
    {

    }
}
