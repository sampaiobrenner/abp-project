namespace Abp.Project.Services.Products;

public interface IProductService
{
    Task AddAsync(CancellationToken cancellationToken);
}