using Chessbot.Domain.Models.Moves;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using static Chessbot.Domain.Models.Moves.SlideBehavior;

namespace Chessbot.Domain.Models.Pieces;
public class Queen : Piece
{
    private static readonly ImmutableList<IBehavior> _moves =
        ImmutableList.Create<IBehavior>(
            North, East, South, West,
            NorthEast, SouthEast, SouthWest, NorthWest
        );

    [SetsRequiredMembers]
    public Queen(PieceColor color) : base(color) { }

    public override ImmutableList<IBehavior> Behaviors => _moves;
}
