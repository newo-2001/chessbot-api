using Chessbot.Api.Configuration;
using Chessbot.Domain.Interfaces;
using Chessbot.Domain.Models;
using Chessbot.Parsing;
using Microsoft.Extensions.Options;
using Stockfish.NET;

namespace Chessbot.Api.Engines;
public class StockFishEngine : IChessEngine
{
    private readonly IStockfish _stockfish;

    public StockFishEngine(IStockfish stockfish)
    {
        _stockfish = stockfish;
    }

    public Task<Move> Move(IReadonlyStateProvider stateProvider)
    {
        var uci = _stockfish.GetBestMove();

        Console.WriteLine($"stockfish moved: {uci}");

        Move move = Parsers.ParseMove(uci);
        Console.WriteLine($"Stockfished moved: {move}");

        return Task.FromResult(move);
    }
}
