using Acme.ProductManagement.Data.EntityTypeConfigurations;
using Acme.ProductManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Acme.ProductManagement.Data.Contexts
{
    public class ProductManagementContext(DbContextOptions<ProductManagementContext> options): DbContext(options)
    {
        public DbSet<ProductCategory> ProductCategory { get; init; }
        public DbSet<Product> Product { get; init; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ProductCategoryEntityTypeConfiguration().Configure(modelBuilder.Entity<ProductCategory>());
            new ProductEntityTypeConfiguration().Configure(modelBuilder.Entity<Product>());
        }
    }
}
