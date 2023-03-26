using Volo.Abp.EventBus;

namespace Abp.Project.Etos;

[EventName("MyApp.Product.StockChange")] // Este será o nome do evento, caso não informado o nome do evento será o Namespace + Nome da classe
public class CreatedProductEto
{
    public Guid ProductId { get; set; }
}