using System.Threading.Tasks;
using DependencyInjection.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace DependencyInjection
{
    public class RandomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RandomMiddleware> _logger;

        public RandomMiddleware(RequestDelegate next, ILogger<RandomMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RandomService randomService)
        {
            var logMessage = $"Get Number from Middleware { randomService.GetNumber() }";

            _logger.LogInformation(logMessage);

            context.Items.Add("RandomMiddleware", logMessage);

            await _next(context);
        }
    }
}
