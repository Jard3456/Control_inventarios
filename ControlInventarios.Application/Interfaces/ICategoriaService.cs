using ControlInventarios.Application.DTOs;

namespace ControlInventarios.Application.Interfaces;

public interface ICategoriaService
{
    Task<IEnumerable<CategoriaDto>> ObtenerTodasAsync();

    Task<CategoriaDto?> ObtenerPorIdAsync(int id);

    Task<CategoriaDto> CrearAsync(CategoriaDto categoria);

    Task<bool> ActualizarAsync(int id, CategoriaDto categoria);

    Task<bool> EliminarAsync(int id);
}