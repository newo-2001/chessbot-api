using System.Text;

namespace Chessbot.Domain.Models;

public class Board
{
    public const int SIZE = 8;

    private readonly Tile?[][] _tiles = new Tile[SIZE][];
    public Tile? TileAt(BoardPosition pos) => _tiles[pos.X][pos.Y];
    public IEnumerable<Tile?> Tiles => _tiles.SelectMany(x => x);

    public Board(Tile?[][] tiles)
    {
        _tiles = tiles;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        for (int y = 0; y < SIZE; y++)
        {
            for (int x = 0; x < SIZE; x++)
            {
                var pos = new BoardPosition(x, y);
                Tile? tile = TileAt(pos);

                builder.Append($" {tile?.ToString() ?? "."} ");
            }
            builder.AppendLine();
        }

        return builder.ToString();
    }
}
