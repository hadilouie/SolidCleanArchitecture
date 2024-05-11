

using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.DatabseContext.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly HrDatabaseContext _context;

    public GenericRepository(HrDatabaseContext _context)
    {
        this._context = _context;
    }

    public async Task CreateAsync(T entity)
    {
        await _context.AddRangeAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
         _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task UpdateAsync(T entity)
    {        
        // or _context.Update(entity);
        _context.Entry(entity).State = EntityState.Modified; 
        await _context.SaveChangesAsync();
    }
}
