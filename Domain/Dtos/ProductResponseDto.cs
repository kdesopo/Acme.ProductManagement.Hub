namespace Acme.ProductManagement.Domain.Dtos;
public class ProductResponseDto
{
    public required string Category { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; }
    public decimal Price { get; set; }
    public required string SKU { get; set; }
    public int Quantity { get; set; }
    public DateTime DateAdded { get; set; }
}
