using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Abp.Project.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : AbpController
{
    [HttpGet]
    public Task<string> GetAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult("Teste");
    }
}