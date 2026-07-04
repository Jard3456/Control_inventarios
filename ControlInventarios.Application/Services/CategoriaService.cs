using ControlInventarios.Application.DTOs;
using ControlInventarios.Application.Interfaces;
using ControlInventarios.Domain.Entities;
using ControlInventarios.Domain.Interfaces;

namespace ControlInventarios.Application.Services;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriaService(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public async Task<IEnumerable<CategoriaDto>> ObtenerTodasAsync()
    {
        var categorias = await _categoriaRepository.ObtenerTodasAsync();

        return categorias.Select(c => new CategoriaDto
        {
            Id = c.Id,
            Nombre = c.Nombre,
            Descripcion = c.Descripcion
        });
    }

    public async Task<CategoriaDto?> ObtenerPorIdAsync(int id)
    {
        var categoria = await _categoriaRepository.ObtenerPorIdAsync(id);

        if (categoria == null)
            return null;

        return new CategoriaDto
        {
            Id = categoria.Id,
            Nombre = categoria.Nombre,
            Descripcion = categoria.Descripcion
        };
    }

    public async Task<CategoriaDto> CrearAsync(CategoriaDto dto)
    {
        var categoria = new Categoria
        {
            Nombre = dto.Nombre,
            Descripcion = dto.Descripcion
        };

        await _categoriaRepository.AgregarAsync(categoria);
        await _categoriaRepository.GuardarCambiosAsync();

        dto.Id = categoria.Id;

        return dto;
    }

    public async Task<bool> ActualizarAsync(int id, CategoriaDto dto)
    {
        var categoria = await _categoriaRepository.ObtenerPorIdAsync(id);

        if (categoria == null)
            return false;

        categoria.Nombre = dto.Nombre;
        categoria.Descripcion = dto.Descripcion;

        await _categoriaRepository.ActualizarAsync(categoria);
        await _categoriaRepository.GuardarCambiosAsync();

        return true;
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var categoria = await _categoriaRepository.ObtenerPorIdAsync(id);

        if (categoria == null)
            return false;

        await _categoriaRepository.EliminarAsync(id);
        await _categoriaRepository.GuardarCambiosAsync();

        return true;
    }
}