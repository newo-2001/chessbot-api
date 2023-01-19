using Chessbot.Domain.Exceptions;
using Chessbot.Domain.Interfaces;
using Chessbot.Domain.Models;
using Chessbot.Parsing;

namespace Chessbot.Api.Players;

public class CliPlayer : IChessPlayer
{
    public async Task<Move> Move(IReadonlyStateProvider stateProvider)
    {
        GameState state = stateProvider.State;
        Console.WriteLine(state.ToString());

        Move? move = null;
        do
        {
            Console.WriteLine("Enter a valid move");
            var uci = await ReadLineAsync();

            move = Parsers.ParseMove(uci);
            Console.WriteLine("Move is not in the correct format");
        } while (move is null);

        return move;
    }

    private static Task<string?> ReadLineAsync() => Task.Run(Console.ReadLine);
}
