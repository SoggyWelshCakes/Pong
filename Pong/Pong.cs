using System.Timers;
using Timer = System.Timers.Timer;

namespace Pong;

static class Pong
{

    public static int menuItem = 0;
    public static int @int = 0;
    public static string[][] numbers =
    [
        [" ▄▄▄▄▄▄▄ ",
         "█  ▄    █",
         "█ █ █   █",
         "█ █ █   █",
         "█ █▄█   █",
         "█       █",
         "█▄▄▄▄▄▄▄█"],

        ["  ▄▄▄▄   ",
         " █    █  ",
         "  █   █  ",
         "  █   █  ",
         "  █   █  ",
         "  █   █  ",
         "  █▄▄▄█  "],

        [" ▄▄▄▄▄▄▄ ",
         "█       █",
         "█▄▄▄▄   █",
         " ▄▄▄▄█  █",
         "█ ▄▄▄▄▄▄█",
         "█ █▄▄▄▄▄ ",
         "█▄▄▄▄▄▄▄█"],

        [" ▄▄▄▄▄▄▄ ",
         "█       █",
         "█▄▄▄    █",
         " ▄▄▄█   █",
         "█▄▄▄    █",
         " ▄▄▄█   █",
         "█▄▄▄▄▄▄▄█"],

        [" ▄   ▄▄▄ ",
         "█ █ █   █",
         "█ █▄█   █",
         "█       █",
         "█▄▄▄    █",
         "    █   █",
         "    █▄▄▄█"],

        [" ▄▄▄▄▄▄▄ ",
         "█       █",
         "█   ▄▄▄▄█",
         "█  █▄▄▄▄ ",
         "█▄▄▄▄▄  █",
         " ▄▄▄▄▄█ █",
         "█▄▄▄▄▄▄▄█"],

        [" ▄▄▄     ",
         "█   █    ",
         "█   █▄▄▄ ",
         "█    ▄  █",
         "█   █ █ █",
         "█   █▄█ █",
         "█▄▄▄▄▄▄▄█"],

        [" ▄▄▄▄▄▄▄ ",
         "█       █",
         "█▄▄▄    █",
         "    █   █",
         "    █   █",
         "    █   █",
         "    █▄▄▄█"],

        ["  ▄▄▄▄▄  ",
         " █  ▄  █ ",
         " █ █▄█ █ ",
         "█   ▄   █",
         "█  █ █  █",
         "█  █▄█  █",
         "█▄▄▄▄▄▄▄█"],

        [" ▄▄▄▄▄▄▄ ",
         "█  ▄    █",
         "█ █ █   █",
         "█ █▄█   █",
         "█▄▄▄    █",
         "    █   █",
         "    █▄▄▄█"],
    ];

    #region secret

    static byte egg = 0; //↑ ↑ ↓ ↓ ← → ← → B A Enter
    readonly static Timer timer = new Timer(500);

    /// <summary>
    /// Togglable egg. 🥚
    /// </summary>
    static void Egg()
    {
        if (timer.Enabled)
        {
            timer.Stop();
            timer.Enabled = false;
            timer.Elapsed -= egg_timer;
        }
        else
        {
            timer.Enabled = true;
            timer.Elapsed += egg_timer;
            timer.Start();
        }
    }

    private static void egg_timer(object? sender, ElapsedEventArgs e) => poop();

    private static void poop()
    {
        if (Console.ForegroundColor == ConsoleColor.Blue) Console.ForegroundColor = ConsoleColor.Yellow;
        else Console.ForegroundColor--;
        MenuUpdate();
    }

    #endregion

    static void Main()
    {
        Menu();
        StartGame();
        Console.WriteLine("THE END");
        Thread.Sleep(-1);
        //look a fidget spinner ߷
    }

    static void Menu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        PongText();

        while (true)
        {
            MenuUpdate();
            ConsoleKey ch = Console.ReadKey(true).Key;
             
            //for easter egg
            switch (ch)
            {
                case ConsoleKey.UpArrow:
                    if (egg == 0 || egg == 1) egg++;
                    else egg = 0;
                    break;

                case ConsoleKey.DownArrow:
                    if (egg == 2 || egg == 3) egg++;
                    else egg = 0;
                    break;

                case ConsoleKey.LeftArrow:
                    if (egg == 4 || egg == 6) egg++;
                    else egg = 0;
                    break;

                case ConsoleKey.RightArrow:
                    if (egg == 5 || egg == 7) egg++;
                    else egg = 0;
                    break;

                case ConsoleKey.B:
                    if (egg == 8) egg++;
                    else egg = 0;
                    break;

                case ConsoleKey.A:
                    if (egg == 9) egg++;
                    else egg = 0;
                    break;

                case ConsoleKey.Enter:
                    if (egg == 10)
                    {
                        Egg();
                        continue;
                    }
                    else
                    {
                        egg = 0;
                        break;
                    }

                default:
                    egg = 0;
                    break;
            }

            switch (ch)
            {
                case ConsoleKey.Enter: break;
                case ConsoleKey.Spacebar: break;

                case ConsoleKey.UpArrow:
                    if (--menuItem < 0) menuItem = 0;
                    continue;
                case ConsoleKey.DownArrow:
                    if (++menuItem > 2) menuItem = 2;
                    continue;

                case ConsoleKey.W: goto case ConsoleKey.UpArrow;
                case ConsoleKey.S: goto case ConsoleKey.DownArrow;

                default: continue;
            }
            break;
        }

        Console.WriteLine(menuItem);
    }

    private static void PongText(int? x = null, int? y = null)
    {
        x ??= (Console.BufferWidth - 42) / 2;
        y ??= 0;

        if (++@int == 10) @int = 0;

        string[] strings = numbers[@int];

        //32 by 7
        int i = 0;
        Console.SetCursorPosition(x.Value, y.Value + i++); Console.Write(" ▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄ ▄▄    ▄ ▄▄▄▄▄▄▄ ");
        Console.SetCursorPosition(x.Value, y.Value + i++); Console.Write("█       █       █  █  █ █       █");
        Console.SetCursorPosition(x.Value, y.Value + i++); Console.Write("█    ▄  █   ▄   █   █▄█ █   ▄▄▄▄█");
        Console.SetCursorPosition(x.Value, y.Value + i++); Console.Write("█   █▄█ █  █ █  █       █  █  ▄▄ ");
        Console.SetCursorPosition(x.Value, y.Value + i++); Console.Write("█    ▄▄▄█  █▄█  █  ▄    █  █ █  █");
        Console.SetCursorPosition(x.Value, y.Value + i++); Console.Write("█   █   █       █ █ █   █  █▄▄█ █");
        Console.SetCursorPosition(x.Value, y.Value + i++); Console.Write("█▄▄▄█   █▄▄▄▄▄▄▄█▄█  █▄▄█▄▄▄▄▄▄▄█");
    }

    static void MenuUpdate()
    {
        if (menuItem < 0 || menuItem > 2)
            throw new ApplicationException($"Item pointer ({menuItem}) is not in the correct range");

        try //if for anyreason this is ran on a non windows os.
        {
#pragma warning disable CA1416 // Validate platform compatibility

            if (Console.BufferHeight < 12) Console.BufferHeight = 12;
            if (Console.BufferWidth < 32) Console.BufferWidth = 32;

#pragma warning restore CA1416 // Validate platform compatibility
        }
        catch (PlatformNotSupportedException)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("MAKE THE WINDOW BIGGER!!!");
            return;
        }

        Console.Clear();
        PongText();

        Console.SetCursorPosition(0, 9);
        Console.Write("     One Player");

        Console.SetCursorPosition(0, 10);
        Console.Write("     Two Player");

        Console.SetCursorPosition(0, 11);
        Console.Write("     Quit");

        Console.SetCursorPosition(2, menuItem + 9);
        Console.Write(">");
    }

    static void StartGame()
    {

    }

}
