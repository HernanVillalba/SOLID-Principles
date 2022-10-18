using ArdalisRating.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public const string policyPath = "policy.json";
        public decimal Rating { get; set; }

        public void Rate()
        {
            Logger.Log<RatingEngine>("Starting rate");

            Logger.Log<RatingEngine>("Loading policy.");

            string policyJson = FilePolicySource.GetPolicyFromsource(path: policyPath);

            Policy policy = Serializer.Deserialize<Policy>(json: policyJson);

            switch (policy.Type)
            {
                case PolicyType.Auto:

                    Logger.Log<RatingEngine>("Rating AUTO policy...");
                    Logger.Log<RatingEngine>("Validating policy.");

                    if (string.IsNullOrEmpty(policy.Make))
                    {
                        Logger.Log<RatingEngine>("Auto policy must specify Make");
                        return;
                    }
                    if (policy.Make == "BMW")
                    {
                        if (policy.Deductible < 500)
                        {
                            Rating = 1000m;
                        }
                        Rating = 900m;
                    }
                    break;

                case PolicyType.Land:
                    Logger.Log<RatingEngine>("Rating LAND policy...");
                    Logger.Log<RatingEngine>("Validating policy.");
                    if (policy.BondAmount == 0 || policy.Valuation == 0)
                    {
                        Logger.Log<RatingEngine>("Land policy must specify Bond Amount and Valuation.");
                        return;
                    }
                    if (policy.BondAmount < 0.8m * policy.Valuation)
                    {
                        Logger.Log<RatingEngine>("Insufficient bond amount.");
                        return;
                    }
                    Rating = policy.BondAmount * 0.05m;
                    break;

                case PolicyType.Life:
                    Logger.Log<RatingEngine>("Rating LIFE policy...");
                    Logger.Log<RatingEngine>("Validating policy.");
                    if (policy.DateOfBirth == DateTime.MinValue)
                    {
                        Logger.Log<RatingEngine>("Life policy must include Date of Birth.");
                        return;
                    }
                    if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
                    {
                        Logger.Log<RatingEngine>("Centenarians are not eligible for coverage.");
                        return;
                    }
                    if (policy.Amount == 0)
                    {
                        Logger.Log<RatingEngine>("Life policy must include an Amount.");
                        return;
                    }
                    int age = DateTime.Today.Year - policy.DateOfBirth.Year;
                    if (policy.DateOfBirth.Month == DateTime.Today.Month &&
                        DateTime.Today.Day < policy.DateOfBirth.Day ||
                        DateTime.Today.Month < policy.DateOfBirth.Month)
                    {
                        age--;
                    }
                    decimal baseRate = policy.Amount * age / 200;
                    if (policy.IsSmoker)
                    {
                        Rating = baseRate * 2;
                        break;
                    }
                    Rating = baseRate;
                    break;

                default:
                    Logger.Log<RatingEngine>("Unknown policy type");
                    break;
            }

            Logger.Log<RatingEngine>("Rating completed.");
        }
    }
}