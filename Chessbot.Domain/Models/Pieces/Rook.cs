using Chessbot.Domain.Models.Moves;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using static Chessbot.Domain.Models.Moves.SlideBehavior;

namespace Chessbot.Domain.Models.Pieces;
public class Rook : Piece
{
    private static readonly ImmutableList<IBehavior> _moves = 
        ImmutableList.Create<IBehavior>(North, East, South, West);
    
    [SetsRequiredMembers]
    public Rook(PieceColor color) : base(color) { }

    public override ImmutableList<IBehavior> Behaviors => _moves;
}
