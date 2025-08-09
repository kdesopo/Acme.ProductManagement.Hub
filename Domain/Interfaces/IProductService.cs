using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Acme.ProductManagement.Domain.Dtos;

namespace Acme.ProductManagement.Domain.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetProductListAsync();
        Task<ProductResponseDto> RegisterNewProductAsync(ProductCreateRequestDto requestDto);

    }
}
