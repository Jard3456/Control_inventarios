using ControlInventarios.Domain.Entities;
using ControlInventarios.Domain.Interfaces;
using ControlInventarios.infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ControlInventarios.infraestructure.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly ControlInventariosDbContext _context;

    public CategoriaRepository(ControlInventariosDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Categoria>> ObtenerTodasAsync()
    {
        return await _context.Categorias
            .AsNoTracking()
            .OrderBy(c => c.Nombre)
            .ToListAsync();
    }

    public async Task<Categoria?> ObtenerPorIdAsync(int id)
    {
        return await _context.Categorias
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AgregarAsync(Categoria categoria)
    {
        await _context.Categorias.AddAsync(categoria);
    }

    public Task ActualizarAsync(Categoria categoria)
    {
        _context.Categorias.Update(categoria);
        return Task.CompletedTask;
    }

    public async Task EliminarAsync(int id)
    {
        var categoria = await ObtenerPorIdAsync(id);

        if (categoria != null)
            _context.Categorias.Remove(categoria);
    }

    public async Task GuardarCambiosAsync()
    {
        await _context.SaveChangesAsync();
    }
}