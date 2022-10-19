using ArdalisRating.Services.Handlers;
using ArdalisRating.Utils;

namespace ArdalisRating.Services.Local;

public class AutoPolicyRater : Rater
{
    private readonly ILoggerService logger;

    public AutoPolicyRater(ILoggerService logger)
    {
        this.logger = logger;
    }

    public override decimal Rate(Policy policy)
    {
        logger.Log<RatingEngine>("Rating AUTO policy...");
        logger.Log<RatingEngine>("Validating policy.");

        if (string.IsNullOrEmpty(policy.Make))
        {
            logger.Log<RatingEngine>("Auto policy must specify Make");

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