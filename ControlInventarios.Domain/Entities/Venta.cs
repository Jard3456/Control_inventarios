namespace ControlInventarios.Domain.Entities;

public class Venta
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public DateTime FechaVenta { get; set; }

    public decimal Total { get; set; }

    public Usuario Usuario { get; set; } = null!;

    public ICollection<DetalleVenta> DetalleVentas { get; set; } = new List<DetalleVenta>();
}