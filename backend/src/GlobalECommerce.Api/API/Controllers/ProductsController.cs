using Asp.Versioning;
using GlobalECommerce.Application.Catalog.DTO;
using GlobalECommerce.Application.Catalog.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GlobalECommerce.Api.Controllers;

[ApiController]
//[Route("api/products")]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var product = await _service.GetByIdAsync(id);

        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductRequest request)
    {
        var product = await _service.CreateAsync(request);

        return CreatedAtAction(
            nameof(Get),
            new { id = product.Id },
            product);
    }
}