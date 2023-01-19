using Chessbot.Domain.Models;

namespace Chessbot.Domain.Interfaces;

public interface IMoveConsumer
{
    void SendMove(Move move);
}
