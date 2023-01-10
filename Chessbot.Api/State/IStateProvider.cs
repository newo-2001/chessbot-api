using Chessbot.Domain.Models;

namespace Chessbot.Api.State
{
    public interface IStateProvider
    {
        public bool IsValid(Move move);
        public GameState State { get; }
        public void Reset();
        public void Move(Move move);
    }
}
