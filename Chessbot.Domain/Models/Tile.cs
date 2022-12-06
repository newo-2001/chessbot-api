namespace Chessbot.Domain.Models;
public record Tile(Piece Piece, PieceColor Color)
{
    public override string ToString() =>
        Color == PieceColor.Black ? Piece.FenName() : Piece.FenName().ToUpper();
}
