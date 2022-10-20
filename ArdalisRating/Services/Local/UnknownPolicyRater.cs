using ArdalisRating.Services.Handlers;
using ArdalisRating.Utils;

namespace ArdalisRating.Services.Local
{
    public class UnknownPolicyRater : Rater
    {
        private readonly ILogger logger;

        public UnknownPolicyRater(ILogger logger)
        {
            this.logger = logger;
        }

        public override decimal Rate(Policy policy)
        {
            logger.Log<RatingEngine>("Unknown policy type");

            return default;
        }
    }
}