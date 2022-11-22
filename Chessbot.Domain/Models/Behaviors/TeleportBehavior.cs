namespace Chessbot.Domain.Models.Moves;
public record TeleportBehavior(Vector2<int> Position) : IBehavior
{
    public TeleportBehavior(int X, int Y) : this(new Vector2<int>(X, Y)) { }

    public IEnumerable<Vector2<int>> Destinations(Vector2<int> origin) => new[] { Position };
}
