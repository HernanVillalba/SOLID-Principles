using ArdalisRating.Services.Handlers;
using ArdalisRating.Utils;

namespace ArdalisRating.Services.Local
{
    public class LandPolicyService : Rater
    {
        private readonly ILogger logger;

        public LandPolicyService(ILogger logger)
        {
            this.logger = logger;
        }

        public override decimal Rate(Policy policy)
        {
            logger.Log<RatingEngine>("Rating LAND policy...");
            logger.Log<RatingEngine>("Validating policy.");

            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                logger.Log<RatingEngine>("Land policy must specify Bond Amount and Valuation.");
                return default;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                logger.Log<RatingEngine>("Insufficient bond amount.");
                return default;
            }

            return policy.BondAmount * 0.05m;
        }
    }
}