using Acme.ProductManagement.Data.Models;
using Acme.ProductManagement.Domain.Dtos;
using Acme.ProductManagement.Domain.Interfaces;

namespace Acme.ProductManagement.Domain.Services;
public class ProductService(IProductRepository productRepository) : IProductService
{
    public async Task<IEnumerable<ProductResponseDto>> GetProductListAsync()
    {
        var products = await productRepository.GetAllProductsAsync();

        return products.Select(product => new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            Code = product.Code,
            Price = product.Price,
            SKU = product.SKU,
            StockQuantity = product.StockQuantity,
            DateAdded = product.DateAdded,
            Category = product.ProductCategory.Name
        });
    }

    public async Task<ProductResponseDto?> GetProductByIdAsync(int id)
    {
        var product = await productRepository.GetProductByIdAsync(id);

        if (product == null)
        {
            return null;
        }

        return new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            Code = product.Code,
            Price = product.Price,
            SKU = product.SKU,
            StockQuantity = product.StockQuantity,
            DateAdded = product.DateAdded,
            Category = product.ProductCategory.Name
        };

    }

    public async Task<ProductResponseDto> RegisterNewProductAsync(ProductCreateRequestDto requestDto)
    {
        var product = new Product
        {
            Name = requestDto.Name,
            Code = requestDto.Code,
            Price = requestDto.Price,
            SKU = requestDto.SKU,
            StockQuantity = requestDto.StockQuantity,
            ProductCategoryId = requestDto.CategoryId
        };

        await productRepository.AddProductAsync(product);
        var savedProduct = productRepository.GetProductByIdAsync(product.Id);

        return new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            Code = product.Code,
            Price = product.Price,
            SKU = product.SKU,
            StockQuantity = product.StockQuantity,
            DateAdded = product.DateAdded,
            Category = product.ProductCategory.Name
        };
    }
}
