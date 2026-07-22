using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Repositories.Interfaces;
using System.Linq.Expressions;

namespace server.Repositories;

public class BaseRepository<TEntity>
    : IBaseRepository<TEntity>
    where TEntity : class
{
    protected readonly ApplicationDbContext Context;

    protected readonly DbSet<TEntity> DbSet;

    public BaseRepository(ApplicationDbContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task AddAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        DbSet.Remove(entity);
    }

    //public async Task SaveChangesAsync()
    //{
    //    await Context.SaveChangesAsync();
    //}

    public async Task<bool> ExistsAsync(
        Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet.AnyAsync(predicate);
    }

    public async Task<TEntity?> FirstOrDefaultAsync(
        Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet.FirstOrDefaultAsync(predicate);
    }
}