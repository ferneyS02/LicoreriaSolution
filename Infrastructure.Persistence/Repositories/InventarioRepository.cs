using LicoreriaSolution.Core.Application.Interfaces.Repositories;
using LicoreriaSolution.Core.Domain.Entities;
using LicoreriaSolution.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LicoreriaSolution.Infrastructure.Repositories;

public class InventarioRepository : IInventarioRepository
{
    private readonly AppDbContext _ctx;
    public InventarioRepository(AppDbContext ctx) => _ctx = ctx;

    public Task<List<Inventario>> GetAllAsync() =>
        _ctx.Inventarios.AsNoTracking().Include(i => i.Producto).ToListAsync();

    public Task<Inventario?> GetByIdAsync(int id) =>
        _ctx.Inventarios.AsNoTracking().Include(i => i.Producto).FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(Inventario entity)
    {
        _ctx.Inventarios.Add(entity);
        await _ctx.SaveChangesAsync();
    }

    public async Task UpdateAsync(Inventario entity)
    {
        _ctx.Inventarios.Update(entity);
        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var existing = await _ctx.Inventarios.FindAsync(id);
        if (existing is null) return;
        _ctx.Inventarios.Remove(existing);
        await _ctx.SaveChangesAsync();
    }
}
