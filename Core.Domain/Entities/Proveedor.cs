namespace LicoreriaSolution.Core.Domain.Entities;

public class Proveedor
{
    public int Id { get; set; }
    public string Nombre { get; set; } = default!;
    public string? Contacto { get; set; }
}
