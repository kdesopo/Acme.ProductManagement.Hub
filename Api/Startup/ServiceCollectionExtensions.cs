using Acme.ProductManagement.Data.Contexts;
using Acme.ProductManagement.Data.Repositories;
using Acme.ProductManagement.Data.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Acme.ProductManagement.Api.Startup
{
    /// <summary>
    /// Contains extension methods for <see cref="Microsoft.Extensions.DependencyInjection.IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureDatabases(
            this IServiceCollection services,
            IConfiguration configuration,
            IWebHostEnvironment env)
        {
            services.AddDbContext<ProductManagementContext>(options =>
            {
                options.UseSqlite("Data Source=AcmeProductManagement.db");

                if (env.IsEnvironment("Local"))
                {
                    options.LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging();
                }
                ;
            });

            return services;
        }

        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }

        public static IServiceCollection ConfigureServiceLayer(this IServiceCollection services)
        {
            // TODO: Wire up service layer once implemented
            return services;
        }
    }
}
