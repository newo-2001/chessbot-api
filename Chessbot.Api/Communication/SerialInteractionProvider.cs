using Chessbot.Domain.Interfaces;
using Chessbot.Domain.Models;
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

    public Task<PieceInteractionEvent> GetPieceInteractionEventAsync()
    {
		Console.WriteLine("Test");
		var line = _serial.ReadLine();
		Console.WriteLine($"Interaction Received: {line}");
        return Task.FromResult(Parsers.ParseInteraction(line));
    }

    public void DiscardBuffer()
    {
        _serial.DiscardInBuffer();
    }
}
