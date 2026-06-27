namespace ControlInventarios.Domain.Entities;

public class Auditoria
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public string Accion { get; set; } = string.Empty;

    public string NombreEntidad { get; set; } = string.Empty;

    public int EntidadId { get; set; }

    public DateTime Fecha { get; set; }

    public Usuario Usuario { get; set; } = null!;
}