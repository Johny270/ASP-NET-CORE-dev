using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    // Entity Framework provides access to the database through a context class
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();
    }
}
