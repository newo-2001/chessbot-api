using Chessbot.Domain.Models;

namespace Chessbot.Domain.Interfaces;
public interface IBoard
{
    ReadOnlySpan<Tile?> Tiles { get; }
    ReadOnlySpan<Tile?> GetRank(int rank);
    Tile? TileAt(BoardPosition position);
    Vector2<int> Dimensions { get; }
}
