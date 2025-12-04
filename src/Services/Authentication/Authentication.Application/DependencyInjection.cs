using Authentication.Application.Common.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(a => a.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly));
            //services.AddValidatorsFromAssemblyContaining<LoginValidator>();
            //services.AddValidatorsFromAssemblyContaining<RegisterValidator>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
