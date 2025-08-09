using Acme.ProductManagement.Domain.Dtos;
using Acme.ProductManagement.Domain.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Acme.ProductManagement.Hub.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var response = await productService.GetProductListAsync();

                return Ok(response);

            }
            catch (Exception ex)
            {
                return Problem(statusCode: 500, title: "Internal Server Error", detail: ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ProductResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var response = await productService.GetProductByIdAsync(id);
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(statusCode: 500, title: "Internal Server Error", detail: ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateNewProduct([FromBody] ProductCreateRequestDto productRequest)
        {
            try
            {
                var response = await productService.RegisterNewProductAsync(productRequest);
                return CreatedAtAction(nameof(GetProduct), new { id = response.Id }, response);
            }
            catch (DbUpdateException dbuEx) when (dbuEx.InnerException is SqliteException sqliteEx && sqliteEx.SqliteErrorCode == 19)
            {
                return Problem(statusCode: 400, title: "Bad Request", detail: dbuEx.InnerException.Message);
            }
            catch (Exception ex)
            {
                return Problem(statusCode: 500, title: "Internal Server Error", detail: ex.Message);
            }
        }
    }
}
