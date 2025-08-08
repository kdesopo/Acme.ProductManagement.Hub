using Acme.ProductManagement.Data.Contexts;

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
                };
            });
            
            return services;
        }
    }
}
