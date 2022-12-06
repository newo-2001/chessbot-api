using Chessbot.Domain.Interfaces;
using Chessbot.Domain.Models;
using Stockfish.NET;

namespace Chessbot.Api.Engines;
public class StockFishEngine : IChessPlayer
{
    private readonly IStockfish _stockfish;

    public StockFishEngine(string stockfishPath)
    {
        _stockfish = new Stockfish.NET.Stockfish(stockfishPath);
    }

    public Move Move(IGameState state)
    {
        var fen = state.FenString;
        Console.WriteLine(fen);
        _stockfish.SetFenPosition(fen);

        // TODO: Update gamestate to reflect stockfish's move
        // e.g. ability to castle, this could be extracted by parsing
        // the fen-string returned by stockfish
        var move = _stockfish.GetBestMove();
        Console.WriteLine("stockfish moved: " + move);
        return Domain.Models.Move.FromUciString(move);
    }
}
