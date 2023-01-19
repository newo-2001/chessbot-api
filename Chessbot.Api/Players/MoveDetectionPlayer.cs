using Chessbot.Domain.Interfaces;
using Chessbot.Domain.Models;
using Microsoft.Extensions.Logging;

namespace Chessbot.Api.Players;

public class MoveDetectionPlayer : IChessPlayer
{
    private readonly IMoveDetector _moveDetector;
    private readonly ILogger<MoveDetectionPlayer> _logger;

    public MoveDetectionPlayer(IMoveDetector moveDetector, ILogger<MoveDetectionPlayer> logger)
    {
        _moveDetector = moveDetector;
        _logger = logger;
    }

    public async Task<Move> Move(IReadonlyStateProvider stateProvider)
    {
        while (true)
        {
            try
            {
                return await _moveDetector.Detect();
            }
            catch (InvalidOperationException e)
            {
                _logger.LogWarning("[WARNING] System entered unstable state and may behave unpredictably:\n\t%s", e.Message);
            }
        }
    }
}
