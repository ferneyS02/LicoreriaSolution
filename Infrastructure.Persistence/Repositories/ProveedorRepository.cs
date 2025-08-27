using LicoreriaSolution.Core.Application.Interfaces.Repositories;
using LicoreriaSolution.Core.Domain.Entities;
using LicoreriaSolution.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LicoreriaSolution.Infrastructure.Repositories;

public class ProveedorRepository : IProveedorRepository
{
    private readonly AppDbContext _ctx;
    public ProveedorRepository(AppDbContext ctx) => _ctx = ctx;

    public Task<List<Proveedor>> GetAllAsync() =>
        _ctx.Proveedores.AsNoTracking().ToListAsync();

    public Task<Proveedor?> GetByIdAsync(int id) =>
        _ctx.Proveedores.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(Proveedor entity)
    {
        _ctx.Proveedores.Add(entity);
        await _ctx.SaveChangesAsync();
    }

    public async Task UpdateAsync(Proveedor entity)
    {
        _ctx.Proveedores.Update(entity);
        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var existing = await _ctx.Proveedores.FindAsync(id);
        if (existing is null) return;
        _ctx.Proveedores.Remove(existing);
        await _ctx.SaveChangesAsync();
    }
}
