using LicoreriaSolution.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LicoreriaSolution.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<Inventario> Inventarios => Set<Inventario>();
        public DbSet<Proveedor> Proveedores => Set<Proveedor>();
        public DbSet<Persona> Personas => Set<Persona>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(e =>
            {
                e.ToTable("Productos");
                e.HasKey(x => x.Id);
                e.Property(x => x.Nombre).IsRequired().HasMaxLength(200);
                e.Property(x => x.Descripcion).HasMaxLength(500);
                e.Property(x => x.Precio).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Inventario>(e =>
            {
                e.ToTable("Inventarios");
                e.HasKey(x => x.Id);
                e.Property(x => x.Cantidad).IsRequired();
                e.Property(x => x.FechaActualizacion).IsRequired();
                e.HasOne(x => x.Producto)
                 .WithMany(p => p.Inventarios)
                 .HasForeignKey(x => x.ProductoId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Proveedor>(e =>
            {
                e.ToTable("Proveedores");
                e.HasKey(x => x.Id);
                e.Property(x => x.Nombre).IsRequired().HasMaxLength(200);
                e.Property(x => x.Contacto).HasMaxLength(200);
            });

            modelBuilder.Entity<Persona>(e =>
            {
                e.ToTable("Personas");
                e.HasKey(x => x.Id);
                e.Property(x => x.Nombre).IsRequired().HasMaxLength(200);
                e.Property(x => x.Rol).IsRequired();
            });
        }
    }
}
