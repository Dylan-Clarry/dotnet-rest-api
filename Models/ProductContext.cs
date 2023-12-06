using Microsoft.EntityFrameworkCore;

namespace dotnet_rest_api.Models;

public class ProductContext : DbContext {
    public ProductContext(DbContextOptions<ProductContext> opts): base(opts) {}
    public DbSet<Product> Products { get; set; } = null!;
}
