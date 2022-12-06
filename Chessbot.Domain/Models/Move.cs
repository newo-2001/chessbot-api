namespace Chessbot.Domain.Models;
public record Move(BoardPosition From, BoardPosition To)
{
    public override string ToString() => $"{From}{To}";

    public static Move FromUciString(string uci) =>
        new(BoardPosition.FromUciString(uci[0..2]), BoardPosition.FromUciString(uci[2..4]));
}
