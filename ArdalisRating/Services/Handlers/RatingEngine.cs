using ArdalisRating.Domain.Enums;
using ArdalisRating.Services.Local;
using ArdalisRating.Utils;

namespace ArdalisRating.Services.Handlers
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        private const string policyPath = "policy.json";
        private readonly AutoPolicyRater autoPolicyRater;
        private readonly LandPolicyService landPolicyService;
        private readonly LifePolicyRater lifePolicyRater;
        private decimal rating;

        public RatingEngine()
        {
            autoPolicyRater = new();
            landPolicyService = new();
            lifePolicyRater = new();
        }

        public void Rate()
        {
            Logger.Log<RatingEngine>("Starting rate");

            Logger.Log<RatingEngine>("Loading policy.");

            string policyJson = FilePolicySource.GetPolicyFromsource(path: policyPath);

            Policy policy = Serializer.Deserialize<Policy>(json: policyJson);

            rating = policy.Type switch
            {
                PolicyType.Auto => autoPolicyRater.Rate(policy),
                PolicyType.Land => landPolicyService.Rate(policy),
                PolicyType.Life => lifePolicyRater.Rate(policy),

                _ => Default()
            };

            Logger.Log<RatingEngine>("Rating completed.");
        }

        private decimal Default()
        {
            Logger.Log<RatingEngine>("Unknown policy type");

            return default;
        }
    }
}