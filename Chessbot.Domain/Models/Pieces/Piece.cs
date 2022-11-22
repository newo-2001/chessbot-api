namespace Chessbot.Domain.Models.Pieces;

using Chessbot.Domain.Models.Moves;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

public abstract class Piece
{
    public required PieceColor Color { get; init; }

    [SetsRequiredMembers]
    public Piece(PieceColor color)
    {
        Color = color;
    }

    public abstract ImmutableList<IBehavior> Behaviors { get; }
}
