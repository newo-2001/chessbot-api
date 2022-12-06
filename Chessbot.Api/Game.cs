using Chessbot.Domain.Interfaces;
using Chessbot.Domain.Models;

public class Game
{
    private readonly IChessPlayer _white;
    private readonly IChessPlayer _black;
    private readonly GameState _gameState = new();

    public IGameState GameState => _gameState;

    public Game(IChessPlayer white, IChessPlayer black)
    {
        _white = white;
        _black = black;
    }

    public Game(IChessPlayer white, IChessPlayer black, GameState gameState)
        : this(white, black)
    {
        _gameState = gameState;
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
