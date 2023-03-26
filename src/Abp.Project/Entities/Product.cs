using Volo.Abp.Domain.Entities;

namespace Abp.Project.Entities;

public class Product : Entity<Guid>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}