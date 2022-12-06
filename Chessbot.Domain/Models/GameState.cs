using Chessbot.Domain.Interfaces;
using System.Text;

namespace Chessbot.Domain.Models;

public class GameState : IGameState
{
    private readonly IEnumerable<PieceColor> _canCastle = new List<PieceColor>();
    private PieceColor _currentColor = PieceColor.White;
    
    public PieceColor CurrentColor
    {
        get => _currentColor;
        set
        {
            if (CurrentColor == PieceColor.Black && value == PieceColor.White)
                MoveNumber++;
            _currentColor = value;
        }
    }

    public Board PlayableBoard { get; init; } = Models.Board.Default();
    public IBoard Board => PlayableBoard;
    public int MoveNumber { get; private set; }

    // TODO: Actually check if the game is finished
    public bool IsFinished => false;

    public string FenString
    {
        get
        {
            var pieces = Enumerable.Range(0, Board.Dimensions.Y)
                .Select(y => FenRank(Board.GetRank(y)))
                .Reverse()
                .Aggregate("", (acc, x) => acc + x + '/')
                .TrimEnd('/');

            var color = CurrentColor == PieceColor.White ? 'w' : 'b';
            var castle = (CanCastle(PieceColor.White) ? "KQ" : "")
                + (CanCastle(PieceColor.Black) ? "kq" : "");
            if (castle == string.Empty) castle = "-";

            // TODO: - Support en-passsant
            //       - Castle on seperate sides
            //       - 50 Move rule

            return $"{pieces} {color} {castle} - 0 {MoveNumber}";
        }
    }

    public bool CanCastle(PieceColor color) => _canCastle.Contains(color);

    private static string FenRank(ReadOnlySpan<Tile?> rank)
    {
        var builder = new StringBuilder();

        int gap = 0;
        foreach (var tile in rank)
        {
            if (tile is null)
            {
                gap++;
                continue;
            }

            if (gap > 0)
            {
                builder.Append(gap);
                gap = 0;
            }
            builder.Append(tile.ToString());
        }

        if (gap > 0) builder.Append(gap);

        return builder.ToString();
    }
}
