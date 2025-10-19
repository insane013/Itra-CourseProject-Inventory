using Course.Database.Entity.Inventory;
using Course.Database.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Course.Database.Repository;

public class FieldInfoRepository : BaseRepository<InventoryFieldInfo>, IFieldInfoRepository
{
    public FieldInfoRepository(InventoryDbContext context)
        : base(context, context.FieldDefinitions)
    {

    }

    public async Task<IEnumerable<InventoryFieldInfo>> GetFromInventory(string InventoryId)
    {
        return await this._dbSet
                    .Where(ii => ii.InventoryId == InventoryId)
                    .Include(fi => fi.Inventory)
                    .AsNoTracking()
                    .ToListAsync();
    }

    public override async Task<InventoryFieldInfo?> GetById(string id)
    {
        return await this._dbSet
            .Include(fi => fi.Inventory)
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == id);
    }
}
