using Abp.Project.Etos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace Abp.Project.Bus;

public class ConsumerCreatedProductEvent : IDistributedEventHandler<CreatedProductEto>, ITransientDependency
{
    public Task HandleEventAsync(CreatedProductEto eventData)
    {
        Console.WriteLine($"Produto cadastrado: {eventData.ProductId}");
        return Task.CompletedTask;
    }
}