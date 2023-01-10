using Chessbot.Domain.Interfaces;
using Chessbot.Domain.Models;
using Stockfish.NET;

namespace Chessbot.Api.Engines;
public class StockFishEngine : IChessEngine
{
    private readonly IStockfish _stockfish;

    public StockFishEngine(string stockfishPath)
    {
        _stockfish = new Stockfish.NET.Stockfish(stockfishPath);
    }

    public Move Move(Move previousMove)
    {
        _stockfish.SetPosition(previousMove.ToString());

        var move = _stockfish.GetBestMove();
        Console.WriteLine("stockfish moved: " + move);
        return Domain.Models.Move.FromUciString(move);
    }
}
