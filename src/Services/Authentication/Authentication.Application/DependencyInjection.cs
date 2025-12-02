using Authentication.Application.Features.Login;
using Authentication.Application.Features.Register;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(a => a.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly));
            services.AddValidatorsFromAssemblyContaining<LoginValidator>();
            services.AddValidatorsFromAssemblyContaining<RegisterValidator>();

            return services;
        }
    }
}
