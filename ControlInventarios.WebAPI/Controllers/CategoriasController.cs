using Microsoft.AspNetCore.Mvc;
using ControlInventarios.Application.DTOs;
using ControlInventarios.Application.Interfaces;

namespace ControlInventarios.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaService _categoriaService;

    public CategoriasController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriaDto>>> ObtenerTodas()
    {
        return Ok(await _categoriaService.ObtenerTodasAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CategoriaDto>> ObtenerPorId(int id)
    {
        var categoria = await _categoriaService.ObtenerPorIdAsync(id);

        if (categoria == null)
            return NotFound();

        return Ok(categoria);
    }

    [HttpPost]
    public async Task<ActionResult<CategoriaDto>> Crear(CategoriaDto categoria)
    {
        var nuevaCategoria = await _categoriaService.CrearAsync(categoria);

        return CreatedAtAction(
            nameof(ObtenerPorId),
            new { id = nuevaCategoria.Id },
            nuevaCategoria);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Actualizar(int id, CategoriaDto categoria)
    {
        var actualizado = await _categoriaService.ActualizarAsync(id, categoria);

        if (!actualizado)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var eliminado = await _categoriaService.EliminarAsync(id);

        if (!eliminado)
            return NotFound();

        return NoContent();
    }
}