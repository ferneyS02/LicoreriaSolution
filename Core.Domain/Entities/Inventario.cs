namespace LicoreriaSolution.Core.Domain.Entities;

public class Inventario
{
    public int Id { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    public DateTime FechaActualizacion { get; set; }

    public Producto Producto { get; set; } = default!;
}
