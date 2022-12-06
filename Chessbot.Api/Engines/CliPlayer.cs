using Chessbot.Domain.Interfaces;
using Chessbot.Domain.Models;

public class CliPlayer : IChessPlayer
{
    public Move Move(IGameState state)
    {
        Console.WriteLine(state.Board.ToString());

        Move? move = null;
        do
        {
            Console.WriteLine("Enter a valid move");
            var uci = Console.ReadLine();

            try
            {
                move = Chessbot.Domain.Models.Move.FromUciString(uci);
            }
            catch
            {
                Console.WriteLine("Invalid move");
            }
        } while (move is null);

        return move;
    }
}
