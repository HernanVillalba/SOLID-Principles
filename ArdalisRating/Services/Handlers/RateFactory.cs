using ArdalisRating.Domain.Enums;
using ArdalisRating.Services.Local;

namespace ArdalisRating.Services.Handlers;

public class RateFactory
{
    public Rater Create(PolicyType policyType)
    {
        return policyType switch
        {
            PolicyType.Auto => new AutoPolicyRater(),
            PolicyType.Land => new LandPolicyService(),
            PolicyType.Life => new LifePolicyRater(),

            _ => default
        };
    }
}