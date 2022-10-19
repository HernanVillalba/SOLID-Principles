using ArdalisRating.Services.Handlers;
using ArdalisRating.Utils;

namespace ArdalisRating.Services.Local
{
    public class UnknownPolicyRater : Rater
    {
        public override decimal Rate(Policy policy)
        {
            Logger.Log<RatingEngine>("Unknown policy type");

            return default;
        }
    }
}