namespace Chessbot.Domain.Models;

public class GameState
{
    public PieceColor CurrentColor { get; } = PieceColor.White;
    public Board Board { get; init; } = Board.Default();
}
