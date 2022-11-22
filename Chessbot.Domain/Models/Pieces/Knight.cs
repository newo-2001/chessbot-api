using Chessbot.Domain.Models.Moves;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace Chessbot.Domain.Models.Pieces;
public class Knight : Piece
{
    private static readonly ImmutableList<IBehavior> _moves =
        ImmutableList.Create<IBehavior>(
            new JumpBehavior(-1, 2), new JumpBehavior(-1, -2),
            new JumpBehavior(1, 2), new JumpBehavior(-1, -2),
            new JumpBehavior(-2, 1), new JumpBehavior(-2, -1),
            new JumpBehavior(2, 1), new JumpBehavior(2, -1)
        );

    [SetsRequiredMembers]
    public Knight(PieceColor color) : base(color) { }

    public override ImmutableList<IBehavior> Behaviors => _moves;
}
