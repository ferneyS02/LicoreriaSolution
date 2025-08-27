using LicoreriaSolution.Core.Domain.Entities;

namespace LicoreriaSolution.Core.Application.Interfaces.Services;

public interface IPersonaService
{
    Task<List<Persona>> GetAllAsync();
    Task<Persona?> GetByIdAsync(int id);
    Task<Persona> CreateAsync(Persona entity);
    Task<bool> UpdateAsync(int id, Persona entity);
    Task<bool> DeleteAsync(int id);
}
