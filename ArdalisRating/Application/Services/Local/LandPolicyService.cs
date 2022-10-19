using ArdalisRating.Domain.Models;
using ArdalisRating.Infrastructure.Services;

namespace ArdalisRating.Application.Services.Local
{
    public class LandPolicyService : Rater
    {
        private readonly ILoggerService logger;

        public LandPolicyService(ILoggerService logger)
        {
            this.logger = logger;
        }

        public override decimal Rate(Policy policy)
        {
            logger.Log<LandPolicyService>("Rating LAND policy...");
            logger.Log<LandPolicyService>("Validating policy.");

            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                logger.Log<LandPolicyService>("Land policy must specify Bond Amount and Valuation.");
                return default;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                logger.Log<LandPolicyService>("Insufficient bond amount.");
                return default;
            }

            return policy.BondAmount * 0.05m;
        }
    }
}