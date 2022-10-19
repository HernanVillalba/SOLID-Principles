using ArdalisRating.Domain.Enums;
using ArdalisRating.Services.Local;

namespace ArdalisRating.Services.Handlers;

public static class RateFactory
{
    public static Rater Create(PolicyType? policyType)
    {
        return policyType switch
        {
            PolicyType.Auto => new AutoPolicyRater(),
            PolicyType.Land => new LandPolicyService(),
            PolicyType.Life => new LifePolicyRater(),

            _ => new UnknownPolicyRater()
        };
    }
}