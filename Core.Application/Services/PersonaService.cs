using LicoreriaSolution.Core.Application.Interfaces.Repositories;
using LicoreriaSolution.Core.Application.Interfaces.Services;
using LicoreriaSolution.Core.Domain.Entities;

namespace LicoreriaSolution.Core.Application.Services;

public class PersonaService : IPersonaService
{
    private readonly IPersonaRepository _repo;
    public PersonaService(IPersonaRepository repo) => _repo = repo;

    public Task<List<Persona>> GetAllAsync() => _repo.GetAllAsync();
    public Task<Persona?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

    public async Task<Persona> CreateAsync(Persona entity)
    {
        if (string.IsNullOrWhiteSpace(entity.Nombre)) throw new ArgumentException("Nombre es requerido");
        await _repo.AddAsync(entity);
        return entity;
    }

    public async Task<bool> UpdateAsync(int id, Persona entity)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing is null) return false;

        existing.Nombre = entity.Nombre;
        existing.Rol = entity.Rol;
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
