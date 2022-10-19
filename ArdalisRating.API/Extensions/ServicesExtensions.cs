using ArdalisRating.Application.Handlers;
using ArdalisRating.Application.Utils;
using ArdalisRating.Infrastructure.Services;

namespace ArdalisRating.API.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IRatingEngine, RatingEngine>();

            services.AddTransient<ILoggerService, ConsoleLoggerService>();
            services.AddTransient<ILoggerService, FileLoggerService>();

            services.AddTransient<IFilePolicySource, FilePolicySource>();
        }
    }
}