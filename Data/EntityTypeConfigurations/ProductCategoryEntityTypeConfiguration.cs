using Acme.ProductManagement.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Acme.ProductManagement.Data.EntityTypeConfigurations;
public class ProductCategoryEntityTypeConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.ToTable("ProductCategory");
        builder.HasKey(pc => pc.Id);
        builder.Property(pc => pc.Id)
            .ValueGeneratedOnAdd();
        builder.Property(pc => pc.Name)
            .IsRequired();
        builder.HasMany(pc => pc.Products)
            .WithOne(p => p.ProductCategory)
            .HasForeignKey(p => p.ProductCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
