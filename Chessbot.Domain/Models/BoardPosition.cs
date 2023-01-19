using System.Security.Cryptography.X509Certificates;

namespace Chessbot.Domain.Models;
public record BoardPosition : Vector2<int>
{
    public BoardPosition(int X, int Y) : base(X, Y) { }

    public override string ToString() => UciString();
        
    public string UciString() => "abcdefgh".Substring(X, 1) + (Y + 1);
}
