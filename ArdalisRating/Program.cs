using ArdalisRating.Services.Handlers;
using ArdalisRating.Utils;
using System;

Console.WriteLine("Ardalis Insurance Rating System Starting...");

RatingEngine engine = new();
engine.Rate();

if (engine?.Rating > 0)
{
    Logger.Log<Program>($"Rating: {engine.Rating}");
}
else
{
    Logger.Log<Program>("No rating produced.");
}