using ArdalisRating.Appplication.Services.Handlers;
using ArdalisRating.Appplication.Services.Local;
using ArdalisRating.Appplication.Utils;
using System;

Console.WriteLine("Ardalis Insurance Rating System Starting...");

ILoggerService logger = new FileLoggerService();
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