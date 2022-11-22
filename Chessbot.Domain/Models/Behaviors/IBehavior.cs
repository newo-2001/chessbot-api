namespace Chessbot.Domain.Models.Moves;
public interface IBehavior
{
    IEnumerable<Vector2<int>> Destinations(Vector2<int> origin);
}
