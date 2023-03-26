using Abp.Project.Entities;
using Abp.Project.Etos;
using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace Abp.Project.Services.Products;

public class ProductService : IProductService, IScopedDependency
{
    private readonly IDistributedEventBus _distributedEventBus;
    private readonly IDistributedCache<Product> _distributedCache;
    public ProductService(IDistributedEventBus distributedEventBus, IDistributedCache<Product> distributedCache)
    {
        _distributedEventBus = distributedEventBus;
        _distributedCache = distributedCache;
    }
    
    public async Task AddAsync(CancellationToken cancellationToken)
    {
        // TODO Adiciona produto na base de dados.
        
        // Publica um evento que um produto foi cadastrado
        await _distributedEventBus.PublishAsync(new CreatedProductEto { ProductId = Guid.NewGuid() });
    }

    public async Task<Product> GetAsync(Guid id, CancellationToken cancellationToken) 
        => await _distributedCache.GetOrAddAsync(id.ToString(),
            async () => await GetProductFromDatabaseAsync(id, cancellationToken),
            () => new DistributedCacheEntryOptions { AbsoluteExpiration = DateTimeOffset.Now.AddHours(1) }, token: cancellationToken);

    private async Task<Product> GetProductFromDatabaseAsync(Guid id, CancellationToken cancellationToken)
    {
        // TODO Obter produto da base de dados.
        return await Task.FromResult(new Product() { Name = "Test", Price = 10m });
    }
}