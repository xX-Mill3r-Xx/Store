using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;

namespace Store.Infrastructure.Persistence;

public sealed class StoreDbContext(DbContextOptions<StoreDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var product = modelBuilder.Entity<Product>();
        product.ToTable("Products");
        product.HasKey(item => item.Id);
        product.Property(item => item.Name).HasMaxLength(100).IsRequired();
        product.Property(item => item.Price).HasPrecision(18, 2).IsRequired();
    }
}
