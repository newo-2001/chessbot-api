using Chessbot.Api.State;
using Chessbot.Domain.Interfaces;
using Chessbot.Domain.Models;

namespace Chessbot.Api;

public class GameRunner : IGameRunner
{
    private readonly IStateProvider _stateProvider;

    public GameState State => _stateProvider.State;

    public GameRunner(IStateProvider stateProvider)
    {
        _stateProvider = stateProvider;
    }

    public async Task Play(IChessPlayer white, IChessPlayer black)
    {
        while (!State.IsFinished)
        {
            var player = State.CurrentColor == PieceColor.White ? white : black;

            Move move;
            while (true)
            {
                move = await player.Move(_stateProvider);
                if (_stateProvider.IsValid(move)) break;

                Console.WriteLine("Invalid move");
            }

            _stateProvider.Move(move);
            
        }
    }
}
