using ArdalisRating.Domain.Models;
using ArdalisRating.Infrastructure.Services;
using System;

namespace ArdalisRating.Application.Services.Local;

public class LifePolicyRater : Rater
{
    private readonly ILoggerService logger;

    public LifePolicyRater(ILoggerService logger)
    {
        this.logger = logger;
    }

    public override decimal Rate(Policy policy)
    {
        logger.Log<LifePolicyRater>("Rating LIFE policy...");
        logger.Log<LifePolicyRater>("Validating policy.");

        if (policy.DateOfBirth == DateTime.MinValue)
        {
            logger.Log<LifePolicyRater>("Life policy must include Date of Birth.");
            return default;
        }
        if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
        {
            logger.Log<LifePolicyRater>("Centenarians are not eligible for coverage.");
            return default;
        }
        if (policy.Amount == 0)
        {
            logger.Log<LifePolicyRater>("Life policy must include an Amount.");
            return default;
        }

        int age = DateTime.Today.Year - policy.DateOfBirth.Year;

        if (policy.DateOfBirth.Month == DateTime.Today.Month &&
            DateTime.Today.Day < policy.DateOfBirth.Day ||
            DateTime.Today.Month < policy.DateOfBirth.Month)
        {
            age--;
        }

        decimal baseRate = policy.Amount * age / 200;

        if (policy.IsSmoker)
        {
            return baseRate * 2;
        }

        return baseRate;
    }
}