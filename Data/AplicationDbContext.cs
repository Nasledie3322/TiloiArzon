using Microsoft.EntityFrameworkCore;
using StoreAPI.Entities;

namespace StoreAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Product>()
        .Property(p => p.Price)
        .HasPrecision(18, 2);

    modelBuilder.Entity<OrderItem>()
        .Property(oi => oi.Price)
        .HasPrecision(18, 2);

    modelBuilder.Entity<Order>()
        .Property(o => o.TotalPrice)
        .HasPrecision(18, 2);
}

}
