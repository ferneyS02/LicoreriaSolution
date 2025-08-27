using LicoreriaSolution.Core.Domain.Entities;

namespace LicoreriaSolution.Core.Application.Interfaces.Services;

public interface IProveedorService
{
    Task<List<Proveedor>> GetAllAsync();
    Task<Proveedor?> GetByIdAsync(int id);
    Task<Proveedor> CreateAsync(Proveedor entity);
    Task<bool> UpdateAsync(int id, Proveedor entity);
    Task<bool> DeleteAsync(int id);
}
