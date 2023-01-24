using Chessbot.Api;
using Chessbot.Api.Communication;
using Chessbot.Api.Configuration;
using Chessbot.Api.Detection;
using Chessbot.Api.Engines;
using Chessbot.Api.Players;
using Chessbot.Api.State;
using Chessbot.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stockfish.NET;
using System.IO.Ports;

var config = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .AddJsonFile("appsettings.json")
    .Build();

var stockFishConfig = config.GetRequiredSection("Stockfish").Get<StockFishConfiguration>();
if (stockFishConfig is null)
{
    throw new ArgumentException("Stockfish configuration is not present!");
}

var stockfish = new Stockfish.NET.Stockfish(stockFishConfig.Path);

var serviceProvider = new ServiceCollection()
    .Configure<StockFishConfiguration>(config.GetSection("Stockfish"))
    .Configure<SerialConfiguration>(config.GetSection("Serial"))
    .AddSingleton<IStockfish>(stockfish)
    .AddSingleton(x =>
    {
        var serialConfig = config.GetRequiredSection("Serial").Get<SerialConfiguration>();
        if (serialConfig is null)
            throw new ArgumentException("Serial configuration is not present!");

        var serial = new SerialPort(serialConfig.PortName, serialConfig.BaudRate);
        serial.Open();
        return serial;
    })
    .AddScoped<IInteractionProvider, SerialInteractionProvider>()
    .AddScoped<IMoveConsumer, SerialMoveConsumer>()
    .AddScoped<IStateProvider, StockFishStateProvider>()
    .AddScoped<IChessEngine, StockFishEngine>()
    .AddScoped<IMoveDetector, MoveDetector>()
    .AddScoped<IGameRunner, GameRunner>()
    .AddScoped<MoveDetectionPlayer>()
    .AddScoped<RobotPlayer>()
    .AddLogging()
    .BuildServiceProvider();

var computer = serviceProvider.GetRequiredService<RobotPlayer>();
var player = serviceProvider.GetRequiredService<MoveDetectionPlayer>();
var runner = serviceProvider.GetRequiredService<IGameRunner>();

await runner.Play(player, computer);

var serial = serviceProvider.GetRequiredService<SerialPort>();
serial.Close();
