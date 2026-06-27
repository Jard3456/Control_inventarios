using ControlInventarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlInventarios.infraestructure.Persistence;

public class ControlInventariosDbContext : DbContext
{
    public ControlInventariosDbContext(
        DbContextOptions<ControlInventariosDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Rol> Roles => Set<Rol>();
    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Producto> Productos => Set<Producto>();
    public DbSet<Venta> Ventas => Set<Venta>();
    public DbSet<DetalleVenta> DetalleVentas => Set<DetalleVenta>();
    public DbSet<Auditoria> Auditorias => Set<Auditoria>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>().ToTable("Usuarios");
        modelBuilder.Entity<Rol>().ToTable("Roles");
        modelBuilder.Entity<Categoria>().ToTable("Categorias");
        modelBuilder.Entity<Producto>().ToTable("Productos");
        modelBuilder.Entity<Venta>().ToTable("Ventas");
        modelBuilder.Entity<DetalleVenta>().ToTable("DetalleVentas");
        modelBuilder.Entity<Auditoria>().ToTable("Auditoria");
    }
}