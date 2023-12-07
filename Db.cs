using Microsoft.EntityFrameworkCore;

class Db : DbContext {
    public Db(DbContextOptions<Db> opts) : base(opts) {}
    public DbSet<Product> Products => Set<Product>();
}
