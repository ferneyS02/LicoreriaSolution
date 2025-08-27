namespace LicoreriaSolution.Core.Domain.Entities;

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = default!;
    public string? Descripcion { get; set; }
    public decimal Precio { get; set; }
    public ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
}
