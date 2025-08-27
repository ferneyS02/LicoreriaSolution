using LicoreriaSolution.Core.Domain.Entities;

namespace LicoreriaSolution.Core.Application.Interfaces.Repositories;

public interface IPersonaRepository
{
    Task<List<Persona>> GetAllAsync();
    Task<Persona?> GetByIdAsync(int id);
    Task AddAsync(Persona entity);
    Task UpdateAsync(Persona entity);
    Task DeleteAsync(int id);
}
