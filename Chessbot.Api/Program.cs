using Chessbot.Api.Configuration;
using Chessbot.Api.Engines;
using Chessbot.Api.Verification;
using Chessbot.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stockfish.NET;

var config = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .AddJsonFile("appsettings.json")
    .Build();

var serviceProvider = new ServiceCollection()
    .Configure<StockFishConfiguration>(options => config.GetSection("Stockfish"))
    .AddSingleton<IStockfish, Stockfish.NET.Stockfish>()
    .AddSingleton<IStateProvider, StockFishStateProvider>()
    .AddScoped<IChessEngine, StockFishEngine>()
    .AddScoped<IChessPlayer, CliPlayer>()
    .AddScoped<IStateProvider, StockFishStateProvider>()
    .BuildServiceProvider();

var stockfishPath = config.GetSection("STOCKFISH_PATH").Value;
stockfishPath ??= config.GetRequiredSection("Stockfish").Value;

var engine = serviceProvider.GetRequiredService<IChessEngine>();
var player = serviceProvider.GetRequiredService<IChessPlayer>();

var game = new Game(engine, player);
game.Play();
