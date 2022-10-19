using ArdalisRating.Domain.Models;

namespace ArdalisRating.Appplication.Services.Local
{
    public abstract class Rater
    {
        public abstract decimal Rate(Policy policy);
    }
}