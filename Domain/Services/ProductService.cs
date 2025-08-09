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
            Name = product.Name,
            Code = product.Code,
            Price = product.Price,
            SKU = product.SKU,
            Quantity = product.Quantity,
            DateAdded = product.DateAdded,
            Category = product.ProductCategory.Name
        });
    }

    public async Task<ProductResponseDto> RegisterNewProductAsync(ProductCreateRequestDto requestDto)
    {
        var product = new Product
        {
            Name = requestDto.Name,
            Code = requestDto.Code,
            Price = requestDto.Price,
            SKU = requestDto.SKU,
            Quantity = requestDto.Quantity,
            ProductCategoryId = requestDto.CategoryId
        };

        await productRepository.AddProductAsync(product);

        return new ProductResponseDto
        {
            Name = product.Name,
            Code = product.Code,
            Price = product.Price,
            SKU = product.SKU,
            Quantity = product.Quantity,
            DateAdded = product.DateAdded,
            Category = product.ProductCategory.Name
        };
    }
}
