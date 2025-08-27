using LicoreriaSolution.Core.Application.Interfaces.Repositories;
using LicoreriaSolution.Core.Application.Interfaces.Services;
using LicoreriaSolution.Core.Domain.Entities;

namespace LicoreriaSolution.Core.Application.Services;

public class ProveedorService : IProveedorService
{
    private readonly IProveedorRepository _repo;
    public ProveedorService(IProveedorRepository repo) => _repo = repo;

    public Task<List<Proveedor>> GetAllAsync() => _repo.GetAllAsync();
    public Task<Proveedor?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

    public async Task<Proveedor> CreateAsync(Proveedor entity)
    {
        if (string.IsNullOrWhiteSpace(entity.Nombre)) throw new ArgumentException("Nombre es requerido");
        await _repo.AddAsync(entity);
        return entity;
    }

    public async Task<bool> UpdateAsync(int id, Proveedor entity)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing is null) return false;

        existing.Nombre = entity.Nombre;
        existing.Contacto = entity.Contacto;
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
