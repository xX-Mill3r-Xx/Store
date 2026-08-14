using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Store.Application.Interfaces;
using Store.Infrastructure.Persistence;
using Store.Infrastructure.Services;

namespace Store.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}
