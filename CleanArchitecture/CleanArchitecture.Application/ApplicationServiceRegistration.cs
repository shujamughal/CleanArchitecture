using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Registers all AutoMapper profiles in the current assembly.
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // Registers all MediatR handlers in the current assembly.
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
