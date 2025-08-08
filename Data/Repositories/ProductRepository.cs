
using Acme.ProductManagement.Data.Contexts;
using Acme.ProductManagement.Data.Models;
using Acme.ProductManagement.Data.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Acme.ProductManagement.Data.Repositories;
public class ProductRepository(ProductManagementContext productManagementContext) : IProductRepository
{
    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await productManagementContext.Product.ToListAsync();
    }

    public async Task AddProduct(Product product)
    {
        await productManagementContext.AddAsync(product);
        await productManagementContext.SaveChangesAsync();
    }
}
