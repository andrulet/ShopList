using Microsoft.EntityFrameworkCore;

namespace ShopList.Models
{
    public class ShopListContext: DbContext
    {
        public DbSet<Shop> Shops { get; set; }

        public DbSet<Product> Products { get; set; }

        public ShopListContext(DbContextOptions<ShopListContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(s => s.Shop)
                .WithMany(p => p.Products)
                .HasForeignKey(fk => fk.ShopId);
        }
    }
}
