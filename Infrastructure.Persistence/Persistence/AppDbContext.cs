using LicoreriaSolution.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LicoreriaSolution.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets → Tablas
        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<Inventario> Inventarios => Set<Inventario>();
        public DbSet<Proveedor> Proveedores => Set<Proveedor>();
        public DbSet<Persona> Personas => Set<Persona>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ====================
            // Producto
            // ====================
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Productos");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Nombre)
                      .IsRequired()
                      .HasMaxLength(200); // PostgreSQL lo convierte en varchar(200)
                entity.Property(p => p.Descripcion)
                      .HasMaxLength(500);
                entity.Property(p => p.Precio)
                      .HasColumnType("numeric(18,2)"); // PostgreSQL usa numeric
            });

            // ====================
            // Inventario
            // ====================
            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.ToTable("Inventarios");
                entity.HasKey(i => i.Id);
                entity.Property(i => i.Cantidad)
                      .IsRequired();
                entity.Property(i => i.FechaActualizacion)
                      .HasColumnType("timestamp"); // PostgreSQL usa timestamp
                entity.HasOne(i => i.Producto)
                      .WithMany(p => p.Inventarios)
                      .HasForeignKey(i => i.ProductoId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // ====================
            // Proveedor
            // ====================
            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.ToTable("Proveedores");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Nombre)
                      .IsRequired()
                      .HasMaxLength(200);
                entity.Property(p => p.Contacto)
                      .HasMaxLength(200);
            });

            // ====================
            // Persona
            // ====================
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("Personas");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Nombre)
                      .IsRequired()
                      .HasMaxLength(200);
                entity.Property(p => p.Rol)
                      .IsRequired(); // PostgreSQL lo traduce como integer
            });
        }
    }
}
