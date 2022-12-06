namespace Chessbot.Domain.Models;
public record BoardPosition : Vector2<int>
{
    public BoardPosition(int X, int Y) : base(X, Y) { }

    public override string ToString() => "abcdefgh".Substring(X, 1) + (Y + 1);

    public static BoardPosition FromUciString(string uci)
        => new("abcdefgh".IndexOf(uci[0]), int.Parse(uci.Substring(1, 1)) - 1);
}
