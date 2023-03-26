using Abp.Project.Entities;

namespace Abp.Project.Services.Products;

public interface IProductService
{
    Task AddAsync(CancellationToken cancellationToken);
    Task<Product> GetAsync(Guid id, CancellationToken cancellationToken);
}