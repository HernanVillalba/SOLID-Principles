using ArdalisRating.Services.Handlers;
using ArdalisRating.Utils;
using System;

Console.WriteLine("Ardalis Insurance Rating System Starting...");

ILogger logger = new Logger();
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