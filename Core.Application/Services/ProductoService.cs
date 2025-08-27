using LicoreriaSolution.Core.Application.Interfaces.Repositories;
using LicoreriaSolution.Core.Application.Interfaces.Services;
using LicoreriaSolution.Core.Domain.Entities;

namespace LicoreriaSolution.Core.Application.Services;

public class ProductoService : IProductoService
{
    private readonly IProductoRepository _repo;
    public ProductoService(IProductoRepository repo) => _repo = repo;

    public Task<List<Producto>> GetAllAsync() => _repo.GetAllAsync();
    public Task<Producto?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

    public async Task<Producto> CreateAsync(Producto entity)
    {
        if (string.IsNullOrWhiteSpace(entity.Nombre)) throw new ArgumentException("Nombre es requerido");
        if (entity.Precio < 0) throw new ArgumentException("Precio no puede ser negativo");

        await _repo.AddAsync(entity);
        return entity;
    }

    public async Task<bool> UpdateAsync(int id, Producto entity)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing is null) return false;

        existing.Nombre = entity.Nombre;
        existing.Descripcion = entity.Descripcion;
        existing.Precio = entity.Precio;

        await _repo.UpdateAsync(existing);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing is null) return false;
        await _repo.DeleteAsync(id);
        return true;
    }
}
