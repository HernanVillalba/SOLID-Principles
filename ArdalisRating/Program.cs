using ArdalisRating.Services.Handlers;
using ArdalisRating.Utils;
using System;

Console.WriteLine("Ardalis Insurance Rating System Starting...");

ILoggerService logger = new LoggerService();
RatingEngine engine = new(logger, new FilePolicySource());

engine.Rate();

if (engine?.Rating > 0)
{
    logger.Log<Program>($"Rating: {engine.Rating}");
}
else
{
    logger.Log<Program>("No rating produced.");
}