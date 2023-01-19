namespace Chessbot.Api.Configuration;

public class SerialConfiguration
{
    public required string PortName { get; set; }
    public required int BaudRate { get; set; }
}
