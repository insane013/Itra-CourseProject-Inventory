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

    public async Task<IEnumerable<InventoryEntity>> GetAll()
    {
        return await this._dbSet
                   .Include(i => i.Creator)
                   .Include(i => i.AccessList)
                   .AsNoTracking()
                   .ToListAsync();
    }

    public override async Task<InventoryEntity?> GetById(Guid id)
    {
        return await this._dbSet
            .Include(i => i.Creator)
            .Include(i => i.AccessList)
            .Include(i => i.CustomFields)
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == id);
    }
}
