using Microsoft.Extensions.DependencyInjection;
using Validator.Domain.Handlers;
using Validator.Domain.UseCases;

namespace Validator.IoC.BootStrapper
{
    public static class InjectorBootStrapper
    {
        public static void RegisterContainerServices(IServiceCollection services)
        {
            services.AddTransient<ValidatorHandler, ValidatorHandler>();
            services.AddTransient<ValidatePassword, ValidatePassword>();
        }
    }

}