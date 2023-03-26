using Abp.Project.Entities;
using Abp.Project.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Abp.Project.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : AbpController
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CancellationToken cancellationToken)
    {
        await _productService.AddAsync(cancellationToken);
        return Ok();
    }
    
    [HttpGet]
    public async Task<Product> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await _productService.GetAsync(id, cancellationToken);
        return product;
    }
}