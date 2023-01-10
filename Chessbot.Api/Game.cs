using Chessbot.Api.State;
using Chessbot.Domain.Interfaces;
using Chessbot.Domain.Models;

public class Game
{
    private readonly IChessPlayer _white;
    private readonly IChessPlayer _black;
    private readonly IStateProvider _stateProvider;

    public GameState State => _stateProvider.State;

    public Game(IStateProvider stateProvider, IChessPlayer white, IChessPlayer black)
    {
        _stateProvider = stateProvider;
        _white = white;
        _black = black;
    }

    public void Play()
    {
        while (!GameState.IsFinished)
        {
            var player = GameState.CurrentColor == PieceColor.White ? _white : _black;
            var move = player.Move(GameState);

            var movedPiece = GameState.Board.TileAt(move.From);
            _gameState.PlayableBoard.SetTileAt(move.To, movedPiece);
            _gameState.PlayableBoard.SetTileAt(move.From, null);

            _gameState.CurrentColor = GameState.CurrentColor.Complement();
        }
    }
}
