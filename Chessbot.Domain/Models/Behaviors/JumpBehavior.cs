namespace Chessbot.Domain.Models.Moves;
public record JumpBehavior(Vector2<int> Offset) : IBehavior
{
    public JumpBehavior(int dx, int dy) : this(new Vector2<int>(dx, dy)) { }

    public IEnumerable<Vector2<int>> Destinations(Vector2<int> origin) => new[] { origin + Offset };
}
