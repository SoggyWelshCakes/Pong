namespace Pong;

public class Game
{ 
    public ushort sizeX { get; }
    public ushort sizeY { get; }
    public byte CompDifficulty { get; }

    public Player P1 { get; }
    public Player P2 { get; }
    public Ball ball { get; }

    //public byte P1S { get; set; } //player size??
    //public byte P2S { get; set; }

    private const ushort maxX = 200;
    private const ushort maxY = 200;
    private const byte maxDifficulty = 10;

    public Game (ushort x, ushort y, byte cd)
    {
        sizeX = x <= maxX ? x : maxX;
        sizeY = y <= maxY ? y : maxY;
        CompDifficulty = cd <= maxDifficulty ? cd : maxDifficulty;

        P1 = new Player(1, (ushort)(sizeY / 2));
        P2 = new Player((ushort)(sizeX - 1), (ushort)(sizeY / 2));
        ball = new Ball((ushort)(sizeX / 2), (ushort)(sizeY / 2));
    }

    public void GameUpdate(Key key)
    {
        switch (key)
        {
            //add verification to ensure positions are in bounds.

            case Key.P1Up:
                P1.Y++;
                break;

            case Key.P1Down:
                P2.Y--;
                break;

            case Key.P2Up:
                if (CompDifficulty != 0) goto case Key.P1Up;
                P2.Y++;
                break;

            case Key.P2Down:
                if (CompDifficulty != 0) goto case Key.P1Down;
                P2.Y--;
                break;

            default: break;
        }
    }

    public enum Key
    {
        Null,
        P1Up,
        P1Down,
        P2Up,
        P2Down,
    }


}
