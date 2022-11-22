using Chessbot.Domain.Models.Moves;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace Chessbot.Domain.Models.Pieces;
public class King : Piece
{
    private static readonly ImmutableList<IBehavior> _moves =
        ImmutableList.CreateRange<IBehavior>(
            Enumerable.Range(-1, 3)
                .SelectMany(x => Enumerable.Range(-1, 3)
                    .Select(y => new JumpBehavior(x, y))
            ).Where(x => x.Offset != Vector2<int>.Zero)
        );

    [SetsRequiredMembers]
    public King(PieceColor color) : base(color) { }

    public override ImmutableList<IBehavior> Behaviors => _moves;
}
