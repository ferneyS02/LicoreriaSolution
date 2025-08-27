using LicoreriaSolution.Core.Application.Interfaces.Services;
using LicoreriaSolution.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LicoreriaSolution.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProveedoresController : ControllerBase
{
    private readonly IProveedorService _service;
    public ProveedoresController(IProveedorService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<List<Proveedor>>> GetAll() =>
        Ok(await _service.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Proveedor>> GetById(int id)
    {
        var item = await _service.GetByIdAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<Proveedor>> Create([FromBody] Proveedor entity)
    {
        var created = await _service.CreateAsync(entity);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] Proveedor entity)
    {
        var ok = await _service.UpdateAsync(id, entity);
        return ok ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => (await _service.DeleteAsync(id)) ? NoContent() : NotFound();
}
