using Store.Domain.Entities;

namespace Store.Application.Interfaces;

public interface IProductService
{
    Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Product> CreateAsync(string name, decimal price, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(int id, string name, decimal price, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
