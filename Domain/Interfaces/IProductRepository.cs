using Acme.ProductManagement.Data.Models;
using Acme.ProductManagement.Domain.Dtos;

namespace Acme.ProductManagement.Domain.Interfaces;
public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task AddProductAsync(Product product);
}
