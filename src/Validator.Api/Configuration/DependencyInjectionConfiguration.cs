using System;
using Microsoft.Extensions.DependencyInjection;
using Validator.IoC.BootStrapper;

namespace Validator.Api.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            InjectorBootStrapper.RegisterContainerServices(services);
        }
    }
}