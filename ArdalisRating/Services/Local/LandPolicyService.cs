using ArdalisRating.Services.Handlers;
using ArdalisRating.Utils;

namespace ArdalisRating.Services.Local
{
    public class LandPolicyService
    {
        public LandPolicyService()
        { }

        public decimal Rate(Policy policy)
        {
            Logger.Log<RatingEngine>("Rating LAND policy...");
            Logger.Log<RatingEngine>("Validating policy.");

            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                Logger.Log<RatingEngine>("Land policy must specify Bond Amount and Valuation.");
                return default;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                Logger.Log<RatingEngine>("Insufficient bond amount.");
                return default;
            }

            return policy.BondAmount * 0.05m;
        }
    }
}