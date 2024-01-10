namespace Pong;
public class Player
{
    public ushort X { get; set; }
    public ushort Y { get; set; }

    public Player(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    #region overrides

    public override bool Equals(object? obj)
    {
        if (obj is not Player) return false;
        Player p = (Player)obj;
        return (X, Y) == (p.X, p.Y);
    }

    public override string ToString() => $"{X},{Y}";
    public override int GetHashCode() => HashCode.Combine(X, Y);

    #endregion

    #region operators

    public static bool operator ==(Player? a, Player? b)
    {
        if (a is null && b is null) return true;
        else if (a is null || b is null) return false;

        else return (a.X, a.Y) == (b.X, b.Y);
    }
    public static bool operator !=(Player? a, Player? b) => !(a == b);

    #endregion

}
