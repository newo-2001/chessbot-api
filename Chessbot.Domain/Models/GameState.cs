namespace Chessbot.Domain.Models
{
    public class GameState
    {
        public required Tile?[][] Tiles { get; init; }
        public required PieceColor CurrentColor { get; init; }
        public required CastleState CastleState { get; init; }
        public BoardPosition? EnPassentSquare { get; init; }
    }
}
