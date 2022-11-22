using Chessbot.Domain.Exceptions;
using Chessbot.Domain.Models.Pieces;
using static Chessbot.Domain.Models.Pieces.PieceColor;

namespace Chessbot.Domain.Models;
public class Board
{
    private readonly Piece?[] _pieces;

    public ReadOnlySpan<Piece?> Pieces => _pieces.AsSpan();

    public Board(IEnumerable<Piece?> pieces)
    {
        if (pieces.Count() != 64)
            throw new ArgumentException($"Expected board to have 64 pieces, got: {pieces.Count()}");

        _pieces = pieces.ToArray();
    }

    public Piece? PieceAt(Vector2<int> position) => _pieces[GetPositionIndex(position)];

    public void Move(Move move)
    {
        AssertValidMove(move);
        
        // TODO: Allow promoting pawns upon reaching other side of the board
        SetPiece(move.To, PieceAt(move.From));
        SetPiece(move.From, null);
    }

    public static Board Default()
    {
        var defaultRow = (PieceColor color) => new Piece?[]
        {
            new Rook(color), new Knight(color), new Bishop(color), new Queen(color),
            new King(color), new Bishop(color), new Knight(color), new Rook(color)
        };

        var pawns = (PieceColor color) => Enumerable.Range(0, 8)
            .Select(_ => new Pawn(color))
            .ToArray<Piece?>();

        var empty = new Piece[8];

        return new Board(new Piece?[][]
        {
            defaultRow(White),
            pawns(White),
            empty, empty, empty, empty,
            pawns(Black),
            defaultRow(Black)
        }.SelectMany(x => x));
    }

    public static bool IsInBounds(Vector2<int> position) =>
        position.X >= 0 && position.Y >= 0 && position.X < 8 && position.Y < 8;
    
    private void SetPiece(Vector2<int> position, Piece? piece)
    {
        _pieces[GetPositionIndex(position)] = piece;
    }

    private void AssertValidMove(Move move)
    {
        var piece = PieceAt(move.From);
        
        if (piece is null)
            throw new IllegalMoveException("There is no piece to move");

        foreach (var behavior in piece.Behaviors)
        {
            foreach (var validMove in behavior.Destinations(move.From))
            {
                if (PieceAt(validMove)?.Color == piece.Color) break;
                // TODO: Validate there are no checks

                if (validMove == move.To) return;
            }
        }

        // TODO: Allow castling
        // TODO: Allow en passant
        
        throw new IllegalMoveException("That piece can't move there");
    }

    private static int GetPositionIndex(Vector2<int> position) => position.Y * 8 + position.X;
}
