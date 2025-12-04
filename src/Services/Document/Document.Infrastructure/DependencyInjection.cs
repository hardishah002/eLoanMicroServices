using Document.Application.Interfaces;
using Document.Application.Services;
using Document.Infrastructure.Persistence;
using Document.Infrastructure.Repositories;
using Document.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Resilience;

namespace Document.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IFileStorageService, FileStorageService>();

            services.AddHttpContextAccessor();

            services.AddHttpClient<ILoanServiceClient, LoanServiceClient>(client =>
            {
                client.BaseAddress = new Uri(configuration["Services:LoanServiceUrl"]);
            })
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                });

            return services;
        }
    }
}
