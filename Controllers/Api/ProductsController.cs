using Microsoft.AspNetCore.Mvc;
using ProductManagement.DTOs;
using ProductManagement.Services.Interfaces;

namespace ProductManagement.Controllers.Api;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    // GET: api/products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
    {
        var products = await _service.GetAllAsync();
        return Ok(products);
    }

    // GET: api/products/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetById(int id)
    {
        var product = await _service.GetByIdAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    // POST: api/products
    [HttpPost]
    public async Task<ActionResult<ProductDto>> Create([FromBody] ProductCreateDto createDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var toCreate = new ProductDto
        {
            Name = createDto.Name,
            Price = createDto.Price,
            Stock = createDto.Stock,
            Description = createDto.Description
        };

        var created = await _service.CreateAsync(toCreate);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // PUT: api/products/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProductDto updateDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        if (id != updateDto.Id) return BadRequest(new { message = "Id in path and body must match." });

        var existing = await _service.GetByIdAsync(id);
        if (existing == null) return NotFound();

        await _service.UpdateAsync(updateDto);
        return NoContent();
    }

    // DELETE: api/products/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _service.GetByIdAsync(id);
        if (existing == null) return NotFound();

        await _service.DeleteAsync(id);
        return NoContent();
    }
}
