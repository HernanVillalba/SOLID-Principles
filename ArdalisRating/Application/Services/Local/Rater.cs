﻿using ArdalisRating.Domain.Models;

namespace ArdalisRating.Application.Services.Local
{
    public abstract class Rater
    {
        public abstract decimal Rate(Policy policy);
    }
}