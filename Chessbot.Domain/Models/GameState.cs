namespace Chessbot.Domain.Models
{
    public class GameState
    {
        public required Board Board { get; init; }
        public required PieceColor CurrentColor { get; init; }
        public required CastleState CastleState { get; init; }
        public BoardPosition? EnPassentSquare { get; init; }

        public bool IsFinished => false; // TODO: implement win detection
    }
}
