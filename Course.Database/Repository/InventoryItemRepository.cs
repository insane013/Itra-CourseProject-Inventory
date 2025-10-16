using Course.Database.Entity.Inventory;
using Course.Database.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Course.Database.Repository;

public class InventoryItemRepository : BaseRepository<InventoryItem>, IInventoryItemRepository
{
    public InventoryItemRepository(InventoryDbContext context)
        : base(context, context.InventoryItems)
    {

    }

    public async Task<IEnumerable<InventoryItem>> GetFromInventory(Guid InventoryId)
    {
        return await this._dbSet
                    .Where(ii => ii.InventoryId == InventoryId)
                    .Include(ii => ii.User)
                    .Include(ii => ii.Likes)
                    .Include(ii => ii.CustomFieldValues)
                        .ThenInclude(cfv => cfv.Field)
                    .AsNoTracking()
                    .ToListAsync();
    }

    public override async Task<InventoryItem?> GetById(Guid id)
    {
        return await this._dbSet
            .Include(ii => ii.User)
            .Include(ii => ii.Likes)
            .Include(ii => ii.CustomFieldValues)
                .ThenInclude(cfv => cfv.Field)
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == id);
    }
}
