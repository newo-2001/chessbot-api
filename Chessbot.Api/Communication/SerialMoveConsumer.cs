using Chessbot.Domain.Interfaces;
using Chessbot.Domain.Models;
using System.IO.Ports;

namespace Chessbot.Api.Communication;

public class SerialMoveConsumer : IMoveConsumer
{
    private readonly SerialPort _serial;

    public SerialMoveConsumer(SerialPort serial)
    {
        _serial = serial;
    }

    public void SendMove(Move move)
    {
        var payload = move.UciString();
        _serial.WriteLine(payload);
    }
}
