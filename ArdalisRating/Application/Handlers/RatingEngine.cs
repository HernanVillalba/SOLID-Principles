using ArdalisRating.Application.Services.Local;
using ArdalisRating.Application.Utils;
using ArdalisRating.Domain.Models;
using ArdalisRating.Infrastructure.Services;
using ArdalisRating.Infrastructure.Utils;

namespace ArdalisRating.Application.Handlers
{
    public interface IRatingEngine
    {
        decimal? Rating { get; set; }

        void Rate(string text = null);
    }

    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine : IRatingEngine
    {
        private readonly ILoggerService logger;
        private readonly IFilePolicySource filePolicySource;
        private const string policyPath = "policy.json";
        public decimal? Rating { get; set; }

        public RatingEngine(ILoggerService logger, IFilePolicySource filePolicySource)
        {
            this.logger = logger;
            this.filePolicySource = filePolicySource;
        }

        public void Rate(string text = null)
        {
            logger.Log<RatingEngine>("Starting rate");

            logger.Log<RatingEngine>("Loading policy.");

            string policyJson;

            if (string.IsNullOrEmpty(text))
            {
                policyJson = filePolicySource.GetPolicyFromsource(path: policyPath);
            }
            else
            {
                policyJson = text;
            }

            Policy policy = Serializer.Deserialize<Policy>(json: policyJson);

            Rater rater = new RateFactory(logger).Create(policy?.Type);

            Rating = rater.Rate(policy);

            logger.Log<RatingEngine>("Rating completed.");
        }
    }
}