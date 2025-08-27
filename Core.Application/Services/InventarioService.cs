using LicoreriaSolution.Core.Application.Interfaces.Repositories;
using LicoreriaSolution.Core.Application.Interfaces.Services;
using LicoreriaSolution.Core.Domain.Entities;

namespace LicoreriaSolution.Core.Application.Services;

public class InventarioService : IInventarioService
{
    private readonly IInventarioRepository _repo;
    private readonly IProductoRepository _productoRepo;

    public InventarioService(IInventarioRepository repo, IProductoRepository productoRepo)
    {
        _repo = repo;
        _productoRepo = productoRepo;
    }

    public Task<List<Inventario>> GetAllAsync() => _repo.GetAllAsync();
    public Task<Inventario?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

    public async Task<Inventario> CreateAsync(Inventario entity)
    {
        var prod = await _productoRepo.GetByIdAsync(entity.ProductoId);
        if (prod is null) throw new ArgumentException("ProductoId no existe");
        if (entity.Cantidad < 0) throw new ArgumentException("Cantidad no puede ser negativa");

        entity.FechaActualizacion = DateTime.UtcNow;
        await _repo.AddAsync(entity);
        return entity;
    }

    public async Task<bool> UpdateAsync(int id, Inventario entity)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing is null) return false;

        if (entity.Cantidad < 0) throw new ArgumentException("Cantidad no puede ser negativa");
        if (existing.ProductoId != entity.ProductoId)
        {
            var prod = await _productoRepo.GetByIdAsync(entity.ProductoId);
            if (prod is null) throw new ArgumentException("ProductoId no existe");
            existing.ProductoId = entity.ProductoId;
        }

        existing.Cantidad = entity.Cantidad;
        existing.FechaActualizacion = DateTime.UtcNow;
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
