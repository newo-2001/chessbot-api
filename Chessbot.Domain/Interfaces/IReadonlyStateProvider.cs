using Chessbot.Domain.Models;

namespace Chessbot.Domain.Interfaces;

public interface IReadonlyStateProvider
{
    public bool IsValid(Move move);
    public GameState State { get; }
}
