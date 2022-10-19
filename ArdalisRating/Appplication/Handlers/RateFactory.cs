using ArdalisRating.Appplication.Services.Local;
using ArdalisRating.Domain.Enums;

namespace ArdalisRating.Appplication.Services.Handlers;

public class RateFactory
{
    private readonly ILoggerService logger;

    public RateFactory(ILoggerService logger)
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