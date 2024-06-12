using Microsoft.EntityFrameworkCore;
using RepositoryPatternAPI.Entity;

namespace RepositoryPatternAPI.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Blog> Blogs { get; set; }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
            .HasOne(o => o.Product)
            .WithMany(o => o.Orders)
            .HasForeignKey(o => o.ProductId);   
        }
    }
}
