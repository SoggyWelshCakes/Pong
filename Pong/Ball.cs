namespace Pong;
public class Ball
{
   public ushort X { get; set; }
   public ushort Y { get; set; }
   public (short x, short y) V { get; set; }

    public Ball(ushort x, ushort y, (short, short)? v = null)
    {
        X = x;
        Y = y;
        V = v ?? (1, 0);
    }

    #region overrides

    public override bool Equals(object? obj)
    {
        if (obj is not Ball) return false;
        Ball p = (Ball)obj;
        return (X, Y) == (p.X, p.Y);
    }

    public override string ToString() => $"{X},{Y},{V.x},{V.y}";
    public override int GetHashCode() => HashCode.Combine(X, Y, V);

    #endregion

    #region operators

    public static bool operator ==(Ball? a, Ball? b)
    {
        if (a is null && b is null) return true;
        else if (a is null || b is null) return false;

        else return (a.X, a.Y, a.V) == (b.X, b.Y, b.V);
    }
    public static bool operator !=(Ball? a, Ball? b) => !(a == b);

    #endregion
}