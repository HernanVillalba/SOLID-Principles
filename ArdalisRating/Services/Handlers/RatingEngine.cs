using ArdalisRating.Domain.Enums;
using ArdalisRating.Services.Local;
using ArdalisRating.Utils;

namespace ArdalisRating.Services.Handlers
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        private const string policyPath = "policy.json";
        public decimal? Rating;

        public void Rate()
        {
            Logger.Log<RatingEngine>("Starting rate");

            Logger.Log<RatingEngine>("Loading policy.");

            string policyJson = FilePolicySource.GetPolicyFromsource(path: policyPath);

            Policy policy = Serializer.Deserialize<Policy>(json: policyJson);

            Rater rater = RateFactory.Create(policy.Type);

            Rating = rater.Rate(policy);

            Logger.Log<RatingEngine>("Rating completed.");
        }
    }
}