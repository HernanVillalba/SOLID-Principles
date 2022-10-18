using ArdalisRating.Services.Handlers;
using ArdalisRating.Utils;

namespace ArdalisRating.Services.Local;

public class AutoPolicyRater : Rater
{
    public AutoPolicyRater()
    { }

    public override decimal Rate(Policy policy)
    {
        Logger.Log<RatingEngine>("Rating AUTO policy...");
        Logger.Log<RatingEngine>("Validating policy.");

        if (string.IsNullOrEmpty(policy.Make))
        {
            Logger.Log<RatingEngine>("Auto policy must specify Make");

            return default;
        }

        decimal rating = 0;

        if (policy.Make == "BMW")
        {
            if (policy.Deductible < 500)
            {
                rating = 1000m;
            }

            rating = 900m;
        }

        return rating;
    }
}