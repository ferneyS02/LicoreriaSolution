using LicoreriaSolution.Core.Application.Interfaces.Repositories;
using LicoreriaSolution.Core.Domain.Entities;
using LicoreriaSolution.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LicoreriaSolution.Infrastructure.Repositories;

public class ProductoRepository : IProductoRepository
{
    private readonly AppDbContext _ctx;
    public ProductoRepository(AppDbContext ctx) => _ctx = ctx;

    public Task<List<Producto>> GetAllAsync() =>
        _ctx.Productos.AsNoTracking().ToListAsync();

    public Task<Producto?> GetByIdAsync(int id) =>
        _ctx.Productos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(Producto entity)
    {
        _ctx.Productos.Add(entity);
        await _ctx.SaveChangesAsync();
    }

    public async Task UpdateAsync(Producto entity)
    {
        _ctx.Productos.Update(entity);
        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var existing = await _ctx.Productos.FindAsync(id);
        if (existing is null) return;
        _ctx.Productos.Remove(existing);
        await _ctx.SaveChangesAsync();
    }
}
