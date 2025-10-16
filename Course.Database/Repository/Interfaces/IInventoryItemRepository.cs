using Course.Database.Entity;

namespace Course.Database.Repository.Interfaces;

public interface IInventoryItemRepository : IRepository<InventoryItem>
{
    public Task<IEnumerable<InventoryItem>> GetFromInventory(Guid InventoryId);
}
