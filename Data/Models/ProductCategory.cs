namespace Acme.ProductManagement.Data.Models;
public class ProductCategory
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
