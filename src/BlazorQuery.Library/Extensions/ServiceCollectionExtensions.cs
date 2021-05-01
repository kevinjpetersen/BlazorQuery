using Microsoft.Extensions.DependencyInjection;

namespace BlazorQuery.Library.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBlazorQuery(this IServiceCollection services)
        {
            services.AddScoped<BlazorQueryDOM>();
            return services;
        }
    }
}
