namespace Chessbot.Domain.Models;
public record Tile(Piece Piece, PieceColor Color)
{
    public override string ToString() =>
        $"{Piece.ToString()[0..2]}-{Color.ToString()[0]}";
}
