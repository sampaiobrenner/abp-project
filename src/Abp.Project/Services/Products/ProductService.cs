using Abp.Project.Etos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace Abp.Project.Services.Products;

public class ProductService : IProductService, IScopedDependency
{
    private readonly IDistributedEventBus _distributedEventBus;

    public ProductService(IDistributedEventBus distributedEventBus)
    {
        _distributedEventBus = distributedEventBus;
    }
    
    public async Task AddAsync(CancellationToken cancellationToken)
    {
        // TODO Adiciona produto na base de dados.
        
        // Publica um evento que um produto foi cadastrado
        await _distributedEventBus.PublishAsync(new CreatedProductEto { ProductId = Guid.NewGuid() });
    }
}