using Acme.ProductManagement.Data.Models;
using Acme.ProductManagement.Domain.Dtos;

namespace Acme.ProductManagement.Domain.Interfaces;
public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product?> GetProductByIdAsync(int id);
    Task AddProductAsync(Product product);
}
