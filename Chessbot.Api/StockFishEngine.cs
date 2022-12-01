using Chessbot.Domain.Interfaces;
using Chessbot.Domain.Models;
using Stockfish.NET;
using System.Text;

namespace Chessbot.Api;
public class StockFishEngine : IChessEngine
{
    private IStockfish _stockfish;

    public GameState GameState => throw new NotImplementedException();

    public void Move(Move move)
    {
        throw new NotImplementedException();
    }

    public StockFishEngine(string stockfishPath)
    {
        _stockfish = new Stockfish.NET.Stockfish(stockfishPath);
    }
}
