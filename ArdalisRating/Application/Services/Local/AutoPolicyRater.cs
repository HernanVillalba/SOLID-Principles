using ArdalisRating.Domain.Models;
using ArdalisRating.Infrastructure.Services;

namespace ArdalisRating.Application.Services.Local;

public class AutoPolicyRater : Rater
{
    private readonly ILoggerService logger;

    public AutoPolicyRater(ILoggerService logger)
    {
        this.logger = logger;
    }

    public override decimal Rate(Policy policy)
    {
        logger.Log<AutoPolicyRater>("Rating AUTO policy...");
        logger.Log<AutoPolicyRater>("Validating policy.");

        if (string.IsNullOrEmpty(policy.Make))
        {
            logger.Log<AutoPolicyRater>("Auto policy must specify Make");

            return default;
        }

        decimal rating = 0;

        if (policy.Make == "BMW")
        {
            if (policy.Deductible < 500)
            {
                return 1000m;
            }

            rating = 900m;
        }

        return rating;
    }
}