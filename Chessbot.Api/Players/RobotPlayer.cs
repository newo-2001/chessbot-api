using Chessbot.Api.Engines;
using Chessbot.Domain.Interfaces;
using Chessbot.Domain.Models;

namespace Chessbot.Api.Players;

public class RobotPlayer : IChessPlayer
{
    private readonly IMoveConsumer _board;
    private readonly IChessEngine _engine;

    public RobotPlayer(IChessEngine engine, IMoveConsumer board)
    {
        _engine = engine;
        _board = board;
    }

    public async Task<Move> Move(IReadonlyStateProvider stateProvider)
    {
        var move = await _engine.Move(stateProvider);
        _board.SendMove(move);
        return move;
    }
}
