using LicoreriaSolution.Core.Domain.Entities;

namespace LicoreriaSolution.Core.Application.Interfaces.Services;

public interface IProductoService
{
    Task<List<Producto>> GetAllAsync();
    Task<Producto?> GetByIdAsync(int id);
    Task<Producto> CreateAsync(Producto entity);
    Task<bool> UpdateAsync(int id, Producto entity);
    Task<bool> DeleteAsync(int id);
}
