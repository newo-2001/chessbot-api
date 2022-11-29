using System.Text;
using static Chessbot.Domain.Models.Piece;
using static Chessbot.Domain.Models.PieceColor;

namespace Chessbot.Domain.Models;
public class Board
{
    private const int SIZE = 8;
    private readonly Tile?[] _tiles = new Tile[SIZE * SIZE];

    public ReadOnlySpan<Tile?> Tiles => _tiles.AsSpan();

    public Tile? TileAt(Vector2<int> pos) => _tiles[pos.Y * SIZE + pos.X];
    public void SetTileAt(Vector2<int> pos, Tile tile) =>
        _tiles[pos.Y * SIZE + pos.X] = tile;

    public Board(Tile?[] tiles)
    {
        _tiles = tiles;
    }

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

        var empty = new Tile?[SIZE];

        return new Board(new Tile?[][]
        {
            defaultRow(White), pawns(White),
            empty, empty, empty, empty,
            pawns(Black), defaultRow(Black)
        }.SelectMany(x => x).ToArray());
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        for (int y = 0; y < SIZE; y++)
        {
            for (int x = 0; x < SIZE; x++)
            {
                builder.Append($"{TileAt(new(x, y))} ");
            }
            builder.AppendLine();
        }

        return builder.ToString();
    }
}
