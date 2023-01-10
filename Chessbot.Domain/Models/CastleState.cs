namespace Chessbot.Domain.Models;

[Flags]
public enum CastleState
{
    None = 0,
    WhiteKingSide = 1,
    WhiteQueenSide = 2,
    BlackKingSide = 4,
    BlackQueenSide = 8
}
