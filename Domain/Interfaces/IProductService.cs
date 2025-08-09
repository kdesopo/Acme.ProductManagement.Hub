using Acme.ProductManagement.Domain.Dtos;

namespace Acme.ProductManagement.Domain.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetProductListAsync();
        Task<ProductResponseDto?> GetProductByIdAsync(int id);
        Task<ProductResponseDto> RegisterNewProductAsync(ProductCreateRequestDto requestDto);

    }
}
