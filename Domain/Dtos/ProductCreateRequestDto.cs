namespace Acme.ProductManagement.Domain.Dtos;
public class ProductCreateRequestDto
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public decimal Price { get; set; }
    public required string SKU { get; set; }
    public int Quantity { get; set; } = 0;
    public int CategoryId { get; set; }
}
