using DependencyInjection;
using DependencyInjection.Interfaces;
using DependencyInjection.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigurationServiceCollectionExtensions
    {
        public static IServiceCollection AddAppConfiguration(this IServiceCollection services)
        {
            services.AddTransient<RandomService>();
            //services.AddScoped<RandomService>();
            //services.AddSingleton<RandomService>();

            services.TryAddEnumerable(new[]
            {
                ServiceDescriptor.Singleton<IMessage, HelloMessageService>(),
                ServiceDescriptor.Singleton<IMessage, ErrorMessageService>()
            });

            return services;
        }
    }
}
