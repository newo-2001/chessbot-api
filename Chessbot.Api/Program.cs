using Chessbot.Api.Engines;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .AddJsonFile("appsettings.json")
    .Build();

var stockfishPath = config.GetSection("STOCKFISH_PATH").Value;
stockfishPath ??= config.GetRequiredSection("Stockfish").Value;

var game = new Game(new StockFishEngine(stockfishPath), new CliPlayer());
game.Play();
