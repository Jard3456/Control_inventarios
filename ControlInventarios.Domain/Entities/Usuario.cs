namespace ControlInventarios.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }

    public string NombreUsuario { get; set; } = string.Empty;

    public string Correo { get; set; } = string.Empty;

    public string ContrasenaHash { get; set; } = string.Empty;

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int RolId { get; set; }

    public Rol Rol { get; set; } = null!;

    public ICollection<Venta> Ventas { get; set; } = new List<Venta>();

    public ICollection<Auditoria> Auditorias { get; set; } = new List<Auditoria>();
}