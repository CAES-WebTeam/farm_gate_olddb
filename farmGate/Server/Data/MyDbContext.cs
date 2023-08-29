using farmGate.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace farmGate.Server.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<County> Counties { get; set; }
        public DbSet<Category> Categories { get; set; }
        // Add other DbSet properties for other tables here
        public DbSet<Commodity> Commodities { get; set; }

        public DbSet<Unit> Units { get; set; }

    }
}
