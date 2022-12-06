namespace Chessbot.Domain.Models;

public enum Piece
{
    Pawn, Bishop, Rook, King, Queen, Knight
}

public static class PieceExtensions
{
    public static string FenName(this Piece piece) => piece switch
    {
        Piece.Pawn => "p",
        Piece.Bishop => "b",
        Piece.Rook => "r",
        Piece.King => "k",
        Piece.Queen => "q",
        Piece.Knight => "n",
        _ => throw new ArgumentException("Invalid piece")
    };
}
