using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorQuery.Extensions
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
