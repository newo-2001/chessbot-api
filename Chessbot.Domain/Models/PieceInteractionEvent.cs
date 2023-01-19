namespace Chessbot.Domain.Models;

public class PieceInteractionEvent
{
    public required PieceInteraction Action { get; init; }
    public required BoardPosition Location { get; init; }
    public DateTime Time { get; init; } = DateTime.UtcNow;

    public bool IsSequential(PieceInteractionEvent previous)
    {
        return previous.Action == PieceInteraction.Lift &&
            Action == PieceInteraction.Drop;
    }

    public bool HasSameLocation(PieceInteractionEvent other) =>
        other.Location == Location;
}

public delegate void PieceInteractionEventHandler(PieceInteractionEvent data);
