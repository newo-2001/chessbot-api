using Chessbot.Domain.Interfaces;
using Chessbot.Domain.Models;
using Chessbot.Parsing;
using Stockfish.NET;

namespace Chessbot.Api.Engines;
public class StockFishEngine : IChessEngine
{
    private readonly IStockfish _stockfish;

    public StockFishEngine(string stockfishPath)
    {
        _stockfish = new Stockfish.NET.Stockfish(stockfishPath);
    }

    public Task<Move> Move(IReadonlyStateProvider stateProvider)
    {
        var uci = _stockfish.GetBestMove();

        Console.WriteLine($"stockfish moved: {uci}");

        Move move = Parsers.ParseMove(uci);

        return Task.FromResult(move);
    }
}
