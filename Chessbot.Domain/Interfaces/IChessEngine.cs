using Chessbot.Domain.Models;

namespace Chessbot.Domain.Interfaces;

public interface IChessEngine
{
    void Move(Move move);
    GameState GameState { get; }
}
