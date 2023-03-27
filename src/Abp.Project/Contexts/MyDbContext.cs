using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Abp.Project.Contexts;

public class MyDbContext : AbpDbContext<MyDbContext>
{
    public MyDbContext(DbContextOptions<MyDbContext> options) 
        : base(options)
    {
    }
}