namespace ArdalisRating.Services.Local
{
    public abstract class Rater
    {
        public abstract decimal Rate(Policy policy);
    }
}