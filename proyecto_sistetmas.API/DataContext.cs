using Microsoft.EntityFrameworkCore;
using proyecto_sistemas.Shared.Entities;
namespace proyecto_sistetmas.API
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DataContext(DbContextOptions<DataContext> dbContext): base(dbContext) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasIndex( x => x.Id).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Brand>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Order>().HasIndex(c => c.Id).IsUnique();

        }

    }
}
