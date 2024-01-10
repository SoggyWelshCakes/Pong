using System.Net.NetworkInformation;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Pong;
internal static class Display
{

    #region text

    public static string[] pong =
        [
            " ▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄ ▄▄    ▄ ▄▄▄▄▄▄▄ ",
            "█       █       █  █  █ █       █",
            "█    ▄  █   ▄   █   █▄█ █   ▄▄▄▄█",
            "█   █▄█ █  █ █  █       █  █  ▄▄ ",
            "█    ▄▄▄█  █▄█  █  ▄    █  █ █  █",
            "█   █   █       █ █ █   █  █▄▄█ █",
            "█▄▄▄█   █▄▄▄▄▄▄▄█▄█  █▄▄█▄▄▄▄▄▄▄█",
        ];

    private static void PongText(int? x = null, int? y = null)
    {
        x ??= (Console.BufferWidth - pong[0].Length) / 2;
        y ??= 0;

        for (int i = 0; i < pong.Length; i++)
        {
            Console.SetCursorPosition(x.Value, y.Value + i); Console.Write(pong[i]);
        }
    }

    public static string[][] numbers =
    [
        [
            " ▄▄▄▄▄▄▄ ",
            "█  ▄    █",
            "█ █ █   █",
            "█ █ █   █",
            "█ █▄█   █",
            "█       █",
            "█▄▄▄▄▄▄▄█"],

        [
            "  ▄▄▄▄   ",
            " █    █  ",
            "  █   █  ",
            "  █   █  ",
            "  █   █  ",
            "  █   █  ",
            "  █▄▄▄█  "],

        [
            " ▄▄▄▄▄▄▄ ",
            "█       █",
            "█▄▄▄▄   █",
            " ▄▄▄▄█  █",
            "█ ▄▄▄▄▄▄█",
            "█ █▄▄▄▄▄ ",
            "█▄▄▄▄▄▄▄█"],

        [
            " ▄▄▄▄▄▄▄ ",
            "█       █",
            "█▄▄▄    █",
            " ▄▄▄█   █",
            "█▄▄▄    █",
            " ▄▄▄█   █",
            "█▄▄▄▄▄▄▄█"],

        [
            " ▄   ▄▄▄ ",
            "█ █ █   █",
            "█ █▄█   █",
            "█       █",
            "█▄▄▄    █",
            "    █   █",
            "    █▄▄▄█"],

        [
            " ▄▄▄▄▄▄▄ ",
            "█       █",
            "█   ▄▄▄▄█",
            "█  █▄▄▄▄ ",
            "█▄▄▄▄▄  █",
            " ▄▄▄▄▄█ █",
            "█▄▄▄▄▄▄▄█"],

        [
            " ▄▄▄     ",
            "█   █    ",
            "█   █▄▄▄ ",
            "█    ▄  █",
            "█   █ █ █",
            "█   █▄█ █",
            "█▄▄▄▄▄▄▄█"],

        [
            " ▄▄▄▄▄▄▄ ",
            "█       █",
            "█▄▄▄    █",
            "    █   █",
            "    █   █",
            "    █   █",
            "    █▄▄▄█"],

        [
            "  ▄▄▄▄▄  ",
            " █  ▄  █ ",
            " █ █▄█ █ ",
            "█   ▄   █",
            "█  █ █  █",
            "█  █▄█  █",
            "█▄▄▄▄▄▄▄█"],

        [
            " ▄▄▄▄▄▄▄ ",
            "█  ▄    █",
            "█ █ █   █",
            "█ █▄█   █",
            "█▄▄▄    █",
            "    █   █",
            "    █▄▄▄█"],
    ];

    #endregion

    #region egg

    static byte eggCount = 0; //↑ ↑ ↓ ↓ ← → ← → B A Enter
    readonly static Timer timer = new Timer(500);

    ///<summary>Togglable egg. 🥚</summary>
    static void Egg()
    {
        if (timer.Enabled)
        {
            timer.Stop();
            timer.Enabled = false;
            timer.Elapsed -= egg_timer;
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            timer.Enabled = true;
            timer.Elapsed += egg_timer;
            timer.Start();
        }
    }

    private static void egg_timer(object? sender, ElapsedEventArgs e) => eggMethod();

    private static void eggMethod()
    {
        if (Console.ForegroundColor == ConsoleColor.Blue) Console.ForegroundColor = ConsoleColor.Yellow;
        else Console.ForegroundColor--;
        Menu.MenuUpdate();
    }

    #endregion

    internal static class Menu
    {

        #region theMenu

        ///<summary>Stores the length of theMenu.</summary>
        private readonly static int length;

        ///<summary>Array containing all menu pages in the format (string[] sa, Action(int) a).</summary>
        private static readonly (string[] sa, Action<int?> a)[] theMenu =
                [
                    //single length strings are for input, it is passed to i.
                    //otherwise the option that was selected will be passed.
/* main menu */     (["Welcome to Pong", "One Player", "Two Player", "Quit"]    , (i) =>
                    {   switch (i)
                        {
                            case 0: twoPlayer = true; menuPage = 1; break;
                            case 1: compDiff = 0; twoPlayer = true; menuPage = 2; break;
                            case 2: menuPage = (sbyte)(length - 2) ; break;
                            default: break;
                        }
                    } ),
/* input comp */    (["Enter Computer Difficulty (1 - 10)"]                     , (i) =>
                    {
                        if (i.HasValue && i > 0 && i <= 10) { compDiff = (int)i; menuPage = 2; }
                        else { tempPage = 1; menuPage = length - 4; }
                    } ),  
/* input gameSize */(["Enter Game Size (50 - 200)"]                             , (i) =>
                    {
                        if (i.HasValue && i >= 50 && i <= 200) { size = (int)i; menuPage = 3; }
                        else { tempPage = 2; menuPage = length - 4; }
                    } ),
/* game ready */    (["Start game?", "Yes", "No"]                               , (i) =>
                    {   //at this step start the game somehow
                        if (i == 0) { gameReady = true; }
                        else menuPage = 0;
                    } ), 
/* ... */
/* input error */   (["Input is invalid"]                                       , (i) => { menuPage = tempPage; } ),
/* debug page */    (["Goto page num:"]                                         , (i) => { menuPage = i ?? length - 3; } ),
/* quit */          (["Are you sure you want to quit?", "No", "Yes"]            , (i) => { if (i == 1) Environment.Exit(314195); else menuPage = 0; } ),  
/* error 404 */     (["Page not found. Press enter to return to the main menu"] , (i) => { menuPage = 0; } )  
                ];

        #endregion

        ///<summary>The current menu selection.</summary>
        private static sbyte menuItem = 0;
        ///<summary>The current menu page</summary>
        private static int menuPage = 0;
        ///<summary>Used in input error page</summary>
        private static int tempPage = 0;
        ///<summary>True if the current page is an input page.</summary>
        private static bool pageIsInput;
        ///<summary>True if all parameters have been set and the game is to be loaded.</summary>
        private static bool gameReady;

        internal static int compDiff;
        internal static int size;
        internal static bool twoPlayer = false;

        private static (string[] sa, Action<int?> a) pageDets;

        static Menu() => length = theMenu.Length;

        ///<summary>Contains the core Menu code.</summary>
        internal static void MenuLoop()
        {
            Console.ForegroundColor = ConsoleColor.White;

            while (!gameReady)
            {
                GetTuple();
                MenuUpdate();

                if (pageIsInput)
                {
                    try
                    {
                        pageDets.a(int.Parse(Console.ReadLine() ?? ""));
                    }
                    catch (Exception)
                    {
                        //tempPage = menuPage;
                        //menuPage = theMenu.Length - 4;
                        pageDets.a(null);
                    }
                }
                else
                {
                    if (Input(Console.ReadKey(true).Key)) pageDets.a(menuItem);
                    else continue;
                }
            }

            //startGame(params); :o;

        }

        internal static void MenuUpdate()
        {
            //Main menu options

            //make sure pageDets has been updated using GetTuple().
            string[] menu = pageDets.sa;
            pageIsInput = menu.Length == 1;

            //validation, also allows for looping.
            if (menuItem > menu.Length - 2) menuItem = 0;
            else if (menuItem < 0) menuItem = (sbyte)(menu.Length - 2);

            Console.Clear();
            PongText();

            Console.SetCursorPosition(0, 8);
            Console.Write(menu.First());

            for (int i = 1; i < menu.Length; i++)
            {
                Console.SetCursorPosition(0, 8 + i);
                Console.Write("     " + menu[i]);
            }

            Console.SetCursorPosition(0, 9 + menuItem);
            Console.Write("  >  ");
        }

        private static void GetTuple()
        {
            try
            {
                pageDets = theMenu[menuPage];
            }
            catch (IndexOutOfRangeException)
            {
                pageDets = theMenu.Last();
            }
        }

        /// <summary>Input for a menu with menu items.</summary>
        /// <returns>True if the enter key (or equivalent) is pressed</returns>
        private static bool Input(ConsoleKey key)
        {
            //for easter egg
            if (menuPage == 0)
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (eggCount == 0 || eggCount == 1) eggCount++;
                        else eggCount = 0;
                        break;

                    case ConsoleKey.DownArrow:
                        if (eggCount == 2 || eggCount == 3) eggCount++;
                        else eggCount = 0;
                        break;

                    case ConsoleKey.LeftArrow:
                        if (eggCount == 4 || eggCount == 6) eggCount++;
                        else eggCount = 0;
                        break;

                    case ConsoleKey.RightArrow:
                        if (eggCount == 5 || eggCount == 7) eggCount++;
                        else eggCount = 0;
                        break;

                    case ConsoleKey.B:
                        if (eggCount == 8) eggCount++;
                        else eggCount = 0;
                        break;

                    case ConsoleKey.A:
                        if (eggCount == 9) eggCount++;
                        else eggCount = 0;
                        break;

                    case ConsoleKey.Enter:
                        if (eggCount == 10)
                        {
                            Egg();
                            return false;
                        }
                        else
                        {
                            eggCount = 0;
                            break;
                        }

                    default:
                        eggCount = 0;
                        break;
                }

            switch (key)
            {
                case ConsoleKey.Enter: return true;
                case ConsoleKey.Spacebar: return true;

                case ConsoleKey.UpArrow:
                    --menuItem;
                    return false;
                case ConsoleKey.DownArrow:
                    ++menuItem;
                    return false;

                case ConsoleKey.W: goto case ConsoleKey.UpArrow;
                case ConsoleKey.S: goto case ConsoleKey.DownArrow;

                default: return false;
            }
        }

    }

}
