using Chessbot.Domain.Models.Moves;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using static Chessbot.Domain.Models.Moves.SlideBehavior;

namespace Chessbot.Domain.Models.Pieces;
public class Bishop : Piece
{
    private static readonly ImmutableList<IBehavior> _moves =
        ImmutableList.Create<IBehavior>(NorthEast, SouthEast, SouthWest, NorthWest);

    [SetsRequiredMembers]
    public Bishop(PieceColor color) : base(color) { }

    public override ImmutableList<IBehavior> Behaviors => _moves;
}
