using Course.Database.Entity.Inventory;
using Course.Database.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Course.Database.Repository;

public class InventoryRepository : BaseRepository<InventoryEntity>, IInventoryRepository
{
    public InventoryRepository(InventoryDbContext context)
        : base(context, context.Inventories)
    {
        
    }

    public IQueryable<InventoryEntity> GetAll()
    {
        return this._dbSet
                   .Include(i => i.Creator)
                   .Include(i => i.AccessList)
                   .AsNoTracking();
    }

    public override async Task<InventoryEntity?> GetById(string id)
    {
        return await this._dbSet
            .Include(i => i.Creator)
            .Include(i => i.AccessList)
            .Include(i => i.CustomFields)
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == id);
    }
}
