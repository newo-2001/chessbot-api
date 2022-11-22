using Chessbot.Domain.Models.Moves;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace Chessbot.Domain.Models.Pieces;
public class Pawn : Piece
{
    private static readonly ImmutableList<IBehavior> _movesWhite =
        ImmutableList.Create<IBehavior>(new JumpBehavior(0, 1));

    private static readonly ImmutableList<IBehavior> _movesBlack =
        ImmutableList.Create<IBehavior>(new JumpBehavior(0, -1));

    [SetsRequiredMembers]
    public Pawn(PieceColor color) : base(color) { }

    // TODO: Allow pawns to move two squares from starting square
    public override ImmutableList<IBehavior> Behaviors =>
        Color == PieceColor.White ? _movesWhite : _movesBlack;
}
