namespace Acme.ProductManagement.Data.Models;
public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; }
    public decimal Price { get; set; }
    public required string SKU { get; set; }
    public int StockQuantity { get; set; }
    public DateTime DateAdded { get; set; } = DateTime.UtcNow;
    public int ProductCategoryId { get; set; }
    public ProductCategory ProductCategory { get; set; }
}
