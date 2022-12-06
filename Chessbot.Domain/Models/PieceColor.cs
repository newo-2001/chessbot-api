namespace Chessbot.Domain.Models;
public enum PieceColor
{
    Black, White
}

public static class PieceColorExtensions
{
    public static PieceColor Complement(this PieceColor color) =>
        color == PieceColor.White ? PieceColor.Black : PieceColor.White;
}
