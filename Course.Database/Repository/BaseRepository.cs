using Course.Database.Entity;
using Course.Database.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Course.Database.Repository;

public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly DbSet<T> _dbSet;
    protected readonly InventoryDbContext context;

    public BaseRepository(InventoryDbContext context, DbSet<T> dbSet)
    {
        this.context = context;
        this._dbSet = dbSet;
    }

    public abstract Task<T?> GetById(Guid id);

    public virtual async Task<T?> Add(T entity)
    {
        var result = await this._dbSet.AddAsync(entity);
        await this.context.SaveChangesAsync();
        return result.Entity;
    }

    public virtual async Task<bool> Delete(Guid id)
    {
        var entity = await this._dbSet.FindAsync(id);

        if (entity is null) return false;

        this._dbSet.Remove(entity);
        await this.context.SaveChangesAsync();

        return true;
    }
    
    public virtual async Task<T?> Update(T entity)
    {
        var existingEntity = await this._dbSet.FindAsync(entity.Id);

        if (existingEntity is null) return null;

        this.context.Entry(existingEntity).CurrentValues.SetValues(entity);
        await this.context.SaveChangesAsync();

        return existingEntity;
    }
}
