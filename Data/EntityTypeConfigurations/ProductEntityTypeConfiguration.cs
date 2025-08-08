using Acme.ProductManagement.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Acme.ProductManagement.Data.EntityTypeConfigurations;
public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // configure the Product entity
        builder.ToTable("Product");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(p => p.Code)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(p => p.Price)
            .HasColumnType("decimal(18,2)");
        builder.Property(p => p.SKU)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(p => p.Quantity)
            .IsRequired();
        builder.Property(p => p.DateAdded)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");
        builder.HasOne(p => p.ProductCategory)
            .WithMany(pc => pc.Products)
            .HasForeignKey(p => p.ProductCategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
