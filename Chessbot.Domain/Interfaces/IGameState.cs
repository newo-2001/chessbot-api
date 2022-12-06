using Chessbot.Domain.Models;

namespace Chessbot.Domain.Interfaces;
public interface IGameState
{
    public PieceColor CurrentColor { get; }
    public IBoard Board { get; }
    public string FenString { get; }
    public bool IsFinished { get; }
    public bool CanCastle(PieceColor color);
    public int MoveNumber { get; }
}
