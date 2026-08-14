using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces;
using Store.Domain.Entities;
using Store.Infrastructure.Persistence;

namespace Store.Infrastructure.Services;

public sealed class ProductService(StoreDbContext context) : IProductService
{
    public async Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await context.Products.AsNoTracking().OrderBy(product => product.Id).ToListAsync(cancellationToken);

    public Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        context.Products.AsNoTracking().FirstOrDefaultAsync(product => product.Id == id, cancellationToken);

    public async Task<Product> CreateAsync(string name, decimal price, CancellationToken cancellationToken = default)
    {
        var product = new Product(name, price);
        context.Products.Add(product);
        await context.SaveChangesAsync(cancellationToken);
        return product;
    }

    public async Task<bool> UpdateAsync(int id, string name, decimal price, CancellationToken cancellationToken = default)
    {
        var product = await context.Products.FindAsync([id], cancellationToken);
        if (product is null) return false;

        product.Update(name, price);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var product = await context.Products.FindAsync([id], cancellationToken);
        if (product is null) return false;

        context.Products.Remove(product);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
