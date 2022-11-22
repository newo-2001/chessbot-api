namespace Chessbot.Domain.Models.Moves;
public record SlideBehavior(Vector2<int> DirectionVector) : IBehavior
{
    public SlideBehavior(int dx, int dy) : this(new Vector2<int>(dx, dy)) { }
    
    public IEnumerable<Vector2<int>> Destinations(Vector2<int> origin)
    {
        for (Vector2<int> position = origin; Board.IsInBounds(position); position += DirectionVector)
        {
            yield return position;
        }
    }

    public static readonly SlideBehavior North = new(0, 1);
    public static readonly SlideBehavior East = new(1, 0);
    public static readonly SlideBehavior South = new(0, -1);
    public static readonly SlideBehavior West = new(-1, 0);

    public static readonly SlideBehavior NorthEast = new(1, 1);
    public static readonly SlideBehavior SouthEast = new(1, -1);
    public static readonly SlideBehavior SouthWest = new(-1, -1);
    public static readonly SlideBehavior NorthWest = new(-1, 1);
}
