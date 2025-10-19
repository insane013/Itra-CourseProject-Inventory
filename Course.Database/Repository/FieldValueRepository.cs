using Course.Database.Entity.Inventory;
using Microsoft.EntityFrameworkCore;

namespace Course.Database.Repository;

public class FieldValueRepository : BaseRepository<InventoryFieldValue>
{
    public FieldValueRepository(InventoryDbContext context)
        : base(context, context.FieldValues)
    {

    }

    public override async Task<InventoryFieldValue?> GetById(string id)
    {
        return await this._dbSet
            .Include(fv => fv.InventoryItem)
            .Include(fv => fv.Field)
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == id);
    }
}
