using System.Security.Cryptography;

namespace Chessbot.Domain.Models
{
    public class InteractionTimeline
    {
        private readonly LinkedList<PieceInteractionEvent> _interactions = new();
        
        // Interactions with the chessboard in reverse chronological order (newest to oldest)
        public IEnumerable<PieceInteractionEvent> Interactions => _interactions;

        public void Append(PieceInteractionEvent data)
        {
            if (_interactions.Any())
            {
                var previous = _interactions.First();
                
                // This move reverted the board to a previous state,
                // so we can simplify the timeline
                if (data.IsSequential(previous) && data.HasSameLocation(previous))
                {
                    _interactions.RemoveFirst();
                }
            }

            _interactions.AddFirst(data);
        }
    }
}
