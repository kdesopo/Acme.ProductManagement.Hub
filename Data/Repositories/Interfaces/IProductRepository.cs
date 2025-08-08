using Acme.ProductManagement.Data.Models;

namespace Acme.ProductManagement.Data.Repositories.Interfaces;
public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProducts();
    Task AddProduct(Product product);
}
