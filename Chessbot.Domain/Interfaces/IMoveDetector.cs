using Chessbot.Domain.Models;

namespace Chessbot.Domain.Interfaces;

public interface IMoveDetector
{
    public Task<Move> Detect();
}
