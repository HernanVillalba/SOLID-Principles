using ArdalisRating.Domain.Enums;
using ArdalisRating.Services.Local;
using ArdalisRating.Utils;

namespace ArdalisRating.Services.Handlers;

public class RateFactory
{
    private readonly ILogger logger;

    public RateFactory(ILogger logger)
    {
        this.logger = logger;
    }

    public Rater Create(PolicyType? policyType)
    {
        return policyType switch
        {
            PolicyType.Auto => new AutoPolicyRater(logger),
            PolicyType.Land => new LandPolicyService(logger),
            PolicyType.Life => new LifePolicyRater(logger),

            _ => new UnknownPolicyRater(logger)
        };
    }
}