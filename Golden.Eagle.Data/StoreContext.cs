using Golden.Eagle.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Golden.Eagle.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        { }

        public DbSet<Item> Items { get; set; }
    }
}


