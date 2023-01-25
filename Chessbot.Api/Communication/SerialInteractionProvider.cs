using Chessbot.Domain.Interfaces;
using Chessbot.Domain.Models;
using Chessbot.Domain.Exceptions;
using Chessbot.Parsing;
using System.IO.Ports;

namespace Chessbot.Api.Communication;

public class SerialInteractionProvider : IInteractionProvider
{
    private readonly SerialPort _serial;

    public SerialInteractionProvider(SerialPort serial)
    {
        _serial = serial;
    }

    public async Task<PieceInteractionEvent> GetPieceInteractionEventAsync()
    {
        var line = await Task.Run(_serial.ReadLine);
        Console.WriteLine($"Received interaction: {line}");
        if (line.StartsWith("reset"))
        {
            throw new MoveInterruptException();
        }

        return Parsers.ParseInteraction(line);
    }

    public void DiscardBuffer()
    {
        _serial.DiscardInBuffer();
    }
}
