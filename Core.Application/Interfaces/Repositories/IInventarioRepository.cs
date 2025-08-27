using LicoreriaSolution.Core.Domain.Entities;

namespace LicoreriaSolution.Core.Application.Interfaces.Repositories;

public interface IInventarioRepository
{
    Task<List<Inventario>> GetAllAsync();
    Task<Inventario?> GetByIdAsync(int id);
    Task AddAsync(Inventario entity);
    Task UpdateAsync(Inventario entity);
    Task DeleteAsync(int id);
}
