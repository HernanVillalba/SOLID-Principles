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
        private readonly ILogger logger;
        private const string policyPath = "policy.json";
        public decimal? Rating;

        public RatingEngine(ILogger logger)
        {
            this.logger = logger;
        }

        public void Rate()
        {
            logger.Log<RatingEngine>("Starting rate");

            logger.Log<RatingEngine>("Loading policy.");

            string policyJson = FilePolicySource.GetPolicyFromsource(path: policyPath);

            Policy policy = Serializer.Deserialize<Policy>(json: policyJson);

            Rater rater = new RateFactory(logger).Create(policy.Type);

            Rating = rater.Rate(policy);

            logger.Log<RatingEngine>("Rating completed.");
        }
    }
}