using LicoreriaSolution.Core.Application.Interfaces.Repositories;
using LicoreriaSolution.Core.Domain.Entities;
using LicoreriaSolution.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LicoreriaSolution.Infrastructure.Repositories;

public class PersonaRepository : IPersonaRepository
{
    private readonly AppDbContext _ctx;
    public PersonaRepository(AppDbContext ctx) => _ctx = ctx;

    public Task<List<Persona>> GetAllAsync() =>
        _ctx.Personas.AsNoTracking().ToListAsync();

    public Task<Persona?> GetByIdAsync(int id) =>
        _ctx.Personas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(Persona entity)
    {
        _ctx.Personas.Add(entity);
        await _ctx.SaveChangesAsync();
    }

    public async Task UpdateAsync(Persona entity)
    {
        _ctx.Personas.Update(entity);
        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var existing = await _ctx.Personas.FindAsync(id);
        if (existing is null) return;
        _ctx.Personas.Remove(existing);
        await _ctx.SaveChangesAsync();
    }
}
