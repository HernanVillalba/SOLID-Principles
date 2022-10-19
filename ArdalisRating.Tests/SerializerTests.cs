using ArdalisRating.Appplication.Utils;
using ArdalisRating.Domain.Enums;
using ArdalisRating.Domain.Models;
using System;
using Xunit;

namespace ArdalisRating.Tests;

public class SerializerTests
{
    [Theory]
    [InlineData("{}")]
    public void Serialize(string input)
    {
        string json = Serializer.Serialize(input);

        Assert.True(condition: !string.IsNullOrEmpty(json));
    }

    [Theory]
    [InlineData("{\"Type\":\"Life\"}")]
    public void Deserialize(string json)
    {
        Policy policy = Serializer.Deserialize<Policy>(json: json);

        Assert.True(Enum.IsDefined<PolicyType>(policy.Type));
    }
}