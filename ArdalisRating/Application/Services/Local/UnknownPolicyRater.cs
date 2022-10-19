using ArdalisRating.Domain.Models;
using ArdalisRating.Infrastructure.Services;

namespace ArdalisRating.Application.Services.Local
{
    public class UnknownPolicyRater : Rater
    {
        private readonly ILoggerService logger;

        public UnknownPolicyRater(ILoggerService logger)
        {
            this.logger = logger;
        }

        public override decimal Rate(Policy policy)
        {
            logger.Log<UnknownPolicyRater>("Unknown policy type");

            return default;
        }
    }
}