using Chessbot.Domain.Interfaces;
using System.Text;
using static Chessbot.Domain.Models.Piece;
using static Chessbot.Domain.Models.PieceColor;

namespace Chessbot.Domain.Models;
public class Board : IBoard
{
    private static readonly Vector2<int> _dimensions = new(8, 8);

    private readonly Tile?[] _tiles = new Tile[_dimensions.X * _dimensions.Y];
    public ReadOnlySpan<Tile?> Tiles => _tiles.AsSpan();
    public ReadOnlySpan<Tile?> GetRank(int rank) => Tiles.Slice(rank * Dimensions.X, Dimensions.X);
    public Vector2<int> Dimensions => _dimensions;

    public Board(Tile?[] tiles)
    {
        _tiles = tiles;
    }

    public Tile? TileAt(BoardPosition pos) => _tiles[pos.Y * Dimensions.X + pos.X];
    
    public override string ToString()
    {
        var builder = new StringBuilder("  a b c d e f g h\n");

        for (int y = 0; y < Dimensions.Y; y++)
        {
            builder.Append($"{y+1} ");
            for (int x = 0; x < Dimensions.X; x++)
            {
                var tile = TileAt(new(x, y))?.ToString() ?? "."; 
                builder.Append(tile + " ");
            }
            builder.AppendLine();
        }

        return builder.ToString();
    }

    public void SetTileAt(BoardPosition pos, Tile? tile) =>
        _tiles[pos.Y * Dimensions.X + pos.X] = tile;

    public static Board Default()
    {
        var pawns = (PieceColor color) => Enumerable.Range(0, 8)
            .Select(_ => new Tile(Pawn, color)).ToArray();

        var defaultRow = (PieceColor color) => new Tile?[]
        {
            new(Rook, color), new(Knight, color), new(Bishop, color),
            new(King, color), new(Queen, color), new(Bishop, color),
            new(Knight, color), new(Rook, color)
        };

        var empty = new Tile?[_dimensions.X];

        return new Board(new Tile?[][]
        {
            defaultRow(White), pawns(White),
            empty, empty, empty, empty,
            pawns(Black), defaultRow(Black)
        }.SelectMany(x => x).ToArray());
    }
}
