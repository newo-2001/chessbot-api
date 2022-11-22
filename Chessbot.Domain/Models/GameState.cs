using Chessbot.Domain.Exceptions;
using Chessbot.Domain.Models.Pieces;
using static Chessbot.Domain.Models.Pieces.PieceColor;

namespace Chessbot.Domain.Models;
public class GameState
{
    public PieceColor ActiveColor { get; private set; } = White;
    public Board Board { get; init; } = Board.Default();

    public void Move(Move move)
    {
        if (move.From == move.To)
            throw new IllegalMoveException("That piece is already in the desired location");

        var complement = ActiveColor.Complement();
        if (Board.PieceAt(move.From)?.Color != ActiveColor)
            throw new IllegalMoveException($"It is not currently {complement}'s turn");
        
        Board.Move(move);
        ActiveColor = complement;
    }
}
