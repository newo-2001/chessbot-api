namespace Chessbot.Domain.Models;
public record Move(Vector2<int> From, Vector2<int> To)
{
    public override string ToString() => $"{From} -> {To}";
}
