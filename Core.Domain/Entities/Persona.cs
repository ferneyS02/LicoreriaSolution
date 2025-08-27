namespace LicoreriaSolution.Core.Domain.Entities;

public enum RolPersona { Vendedor = 1, Admin = 2 }

public class Persona
{
    public int Id { get; set; }
    public string Nombre { get; set; } = default!;
    public RolPersona Rol { get; set; }
}
