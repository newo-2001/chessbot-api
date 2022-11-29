using Chessbot.Api;
using Microsoft.Extensions.Configuration;

Console.WriteLine("Hello, World!");

var config = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .AddJsonFile("appsettings.json")
    .Build();

foreach (var section in config.AsEnumerable().ToList())
{
    Console.WriteLine(section);
}

var stockfishPath = config.GetSection("STOCKFISH_PATH").Value
        ?? config.GetRequiredSection("Stockfish").Value;
var stockfish = new StockFishEngine(stockfishPath);

