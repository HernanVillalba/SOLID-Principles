using ArdalisRating.Appplication.Services.Local;
using ArdalisRating.Appplication.Utils;
using ArdalisRating.Domain.Models;

namespace ArdalisRating.Appplication.Services.Handlers
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        private readonly ILoggerService logger;
        private readonly IFilePolicySource filePolicySource;
        private const string policyPath = "policy.json";
        public decimal? Rating;

        public RatingEngine(ILoggerService logger, IFilePolicySource filePolicySource)
        {
            this.logger = logger;
            this.filePolicySource = filePolicySource;
        }

        public void Rate()
        {
            logger.Log<RatingEngine>("Starting rate");

            logger.Log<RatingEngine>("Loading policy.");

            string policyJson = filePolicySource.GetPolicyFromsource(path: policyPath);

            Policy policy = Serializer.Deserialize<Policy>(json: policyJson);

            Rater rater = new RateFactory(logger).Create(policy.Type);

            Rating = rater.Rate(policy);

            logger.Log<RatingEngine>("Rating completed.");
        }
    }
}