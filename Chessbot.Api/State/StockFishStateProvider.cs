using Chessbot.Domain.Models;
using Stockfish.NET;
using Chessbot.Parsing;

namespace Chessbot.Api.State
{
    public class StockFishStateProvider : IStateProvider
    {
        private const string START_FEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w ---- - 0 1";
        private LinkedList<Move> _moves = new();

        private readonly IStockfish _stockfish;

        public StockFishStateProvider(IStockfish stockfish)
        {
            _stockfish = stockfish;
        }

        public GameState State
        {
            get
            {
                var fen = _stockfish.GetFenPosition();
                return Parsers.ParseGameState(fen);
            }
        }

        public bool IsValid(Move move) =>
            _stockfish.IsMoveCorrect(move.UciString());

        public void Move(Move move)
        {
            _moves.AddLast(move);
            _stockfish.SetPosition(_moves.Select(x => x.ToString()).ToArray());
        }

        public void Reset()
        {
            _stockfish.SetFenPosition(START_FEN);
            _moves.Clear();
        }
    }
}
