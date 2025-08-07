using Microsoft.EntityFrameworkCore;

namespace Acme.ProductManagement.Data.Contexts
{
    public class ProductManagementContext(DbContextOptions<ProductManagementContext> options): DbContext(options)
    {
    }
}
