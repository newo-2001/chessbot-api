using Chessbot.Domain.Interfaces;
using Chessbot.Domain.Models;

namespace Chessbot.Api.State
{
    public interface IStateProvider : IReadonlyStateProvider
    {
        public void Reset();
        public void Move(Move move);
    }
}
