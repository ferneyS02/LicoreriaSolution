using LicoreriaSolution.Core.Domain.Entities;

namespace LicoreriaSolution.Core.Application.Interfaces.Repositories;

public interface IProveedorRepository
{
    Task<List<Proveedor>> GetAllAsync();
    Task<Proveedor?> GetByIdAsync(int id);
    Task AddAsync(Proveedor entity);
    Task UpdateAsync(Proveedor entity);
    Task DeleteAsync(int id);
}
