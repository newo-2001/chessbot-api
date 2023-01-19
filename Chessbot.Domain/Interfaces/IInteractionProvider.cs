using Chessbot.Domain.Models;

namespace Chessbot.Domain.Interfaces;

public interface IInteractionProvider
{
    Task<PieceInteractionEvent> GetPieceInteractionEventAsync();
    void DiscardBuffer();
}
