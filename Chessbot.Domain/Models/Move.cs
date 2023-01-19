namespace Chessbot.Domain.Models;
public record Move(BoardPosition From, BoardPosition To)
{
    public override string ToString() => UciString();
    public string UciString() => $"{From.UciString()}{To.UciString()}";
}
