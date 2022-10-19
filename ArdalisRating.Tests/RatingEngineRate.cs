using ArdalisRating.Domain.Enums;
using ArdalisRating.Services.Handlers;
using ArdalisRating.Utils;
using Newtonsoft.Json;
using System.IO;
using Xunit;

namespace ArdalisRating.Tests;

public class RatingEngineRate
{
    [Theory]
    [InlineData("policy.json")]
    public void ReturnsRatingOf10000For200000LandPolicy(string policyPath)
    {
        FilePolicySource filePolicySource = new();

        Policy policy = new()
        {
            Type = PolicyType.Land,
            BondAmount = 200000,
            Valuation = 200000
        };

        string json = Serializer.Serialize(policy);

        filePolicySource.WriteInfile(path: policyPath, text: json);

        RatingEngine engine = new(new LoggerService(), new FilePolicySource());
        engine.Rate();
        decimal? result = engine.Rating;

        Assert.Equal(10000, result);
    }

    [Theory]
    [InlineData("policy.json")]
    public void ReturnsRatingOf0For200000BondOn260000LandPolicy(string policyPath)
    {
        FilePolicySource filePolicySource = new();

        Policy policy = new()
        {
            Type = PolicyType.Land,
            BondAmount = 200000,
            Valuation = 260000
        };

        string json = Serializer.Serialize(policy);

        filePolicySource.WriteInfile(path: policyPath, text: json);

        RatingEngine engine = new(new LoggerService(), filePolicySource);
        engine.Rate();
        decimal? result = engine.Rating;

        Assert.Equal(0, result);
    }
}