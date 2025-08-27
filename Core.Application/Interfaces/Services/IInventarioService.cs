using LicoreriaSolution.Core.Domain.Entities;

namespace LicoreriaSolution.Core.Application.Interfaces.Services;

public interface IInventarioService
{
    Task<List<Inventario>> GetAllAsync();
    Task<Inventario?> GetByIdAsync(int id);
    Task<Inventario> CreateAsync(Inventario entity);
    Task<bool> UpdateAsync(int id, Inventario entity);
    Task<bool> DeleteAsync(int id);
}
