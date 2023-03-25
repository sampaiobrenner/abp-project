using System.Text;
using Abp.Project.Services;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Abp.Project.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlobController : AbpController
{
    private readonly IBlobService _blobService;

    public BlobController(IBlobService blobService)
    {
        _blobService = blobService;
    }
    
    [HttpPost]
    public async Task SaveAsync(CancellationToken cancellationToken)
    {
        var name = Guid.NewGuid().ToString();
        var bytes = Encoding.UTF8.GetBytes(Guid.NewGuid().ToString());
        
        await _blobService.SaveAsync(name, bytes, cancellationToken);
    }
}