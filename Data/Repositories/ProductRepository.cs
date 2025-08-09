
using Acme.ProductManagement.Data.Contexts;
using Acme.ProductManagement.Data.Models;
using Acme.ProductManagement.Domain.Dtos;
using Acme.ProductManagement.Domain.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Acme.ProductManagement.Data.Repositories;
public class ProductRepository(ProductManagementContext productManagementContext) : IProductRepository
{
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await productManagementContext.Product
            .Include(p => p.ProductCategory)
            .ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await productManagementContext.Product
            .Include(p => p.ProductCategory)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddProductAsync(Product product)
    {
        await productManagementContext.AddAsync(product);
        await productManagementContext.SaveChangesAsync();
    }
}
