using Chessbot.Domain.Exceptions;
using Chessbot.Domain.Interfaces;
using Chessbot.Domain.Models;

namespace Chessbot.Api.Detection;

public class MoveDetector : IMoveDetector
{
    private readonly IInteractionProvider _interactionProvider;
    private readonly InteractionTimeline _timeline = new();

    public MoveDetector(IInteractionProvider interactionProvider)
    {
        _interactionProvider = interactionProvider;
    }

    public async Task<Move> Detect()
    {
        Console.WriteLine("Listening for interactions...");
        Move? move = null;
        while (move is null)
        {
            try
            {
                var interaction = await _interactionProvider.GetPieceInteractionEventAsync();
                _timeline.Append(interaction);
                move = FindMove();
            }
            catch (MoveInterruptException)
            {
                Console.WriteLine("Move timeline has been reset.");
                _timeline.Reset();
            }
        }
        Console.WriteLine($"Move detected: {move}");

        return move!;
    }

    private Move? FindMove()
    {
        return _timeline.Interactions.Count() switch
        {
            0 => null,
            1 => _timeline.Interactions.First().Action != PieceInteraction.Lift
                ? throw new InvalidOperationException("Expected first action to be lift")
                : null,
            2 => MoveToEmpty(),
            3 => AttackPiece(),
            _ => throw new InvalidOperationException("Failed to detect a move after more than 3 actions!")
        };
    }

    private Move? MoveToEmpty()
    {
        var interactions = _timeline.Interactions;
        var latest = interactions.First();
        var prev = interactions.Skip(1).First();

        // If there are only two actions and they are not sequential
        // there can't be a move
        if (!latest.IsSequential(prev))
            return null;

        return new Move(prev.Location, latest.Location);
    }

    private Move? AttackPiece()
    {
        var interactions = _timeline.Interactions;
        var place = interactions.First();
        var attacked = interactions.Skip(1).First();
        var origin = interactions.Skip(2).First();

        if (!place.IsSequential(attacked) ||
            !place.HasSameLocation(attacked))
        {
            throw new InvalidOperationException("Failed to detect move, expected latest action to replace previous piece");
        }

        return new Move(origin.Location, place.Location);
    }
}
