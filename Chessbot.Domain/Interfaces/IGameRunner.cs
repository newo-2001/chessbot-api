namespace Chessbot.Domain.Interfaces;

public interface IGameRunner
{
    Task Play(IChessPlayer white, IChessPlayer black);
}
