using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControlInventarios.infraestructure.Persistence;

namespace ControlInventarios.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    private readonly ControlInventariosDbContext _context;

    public CategoriasController(ControlInventariosDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerCategorias()
    {
        var categorias = await _context.Categorias.ToListAsync();

        return Ok(categorias);
    }
}