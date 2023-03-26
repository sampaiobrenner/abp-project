using Volo.Abp.Caching;
using Volo.Abp.Domain.Entities;

namespace Abp.Project.Entities;

[CacheName(nameof(Product))]
public class Product : Entity<Guid>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}