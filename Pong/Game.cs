using System.ComponentModel.DataAnnotations;

namespace Pong;

internal class Game
{ 
    public ushort X { get; }
    public ushort Y { get; }

    private const ushort maxX = 200;
    private const ushort maxY = 200;

    private Player p1 { get; set; }
    private Player p2 { get; set; }
    private Ball ball { get; set; }

    public Game (ushort x, ushort y)
    {
        if (x > maxX) x = maxX;
        if (y > maxY) y = maxY;
        X = x;
        Y = y;  


    }


}
