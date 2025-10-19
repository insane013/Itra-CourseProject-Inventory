using Course.Database.Entity.Inventory;

namespace Course.Database.Repository.Interfaces;

public interface IInventoryItemRepository : IRepository<InventoryItem>
{
    public Task<IEnumerable<InventoryItem>> GetFromInventory(string InventoryId);
}
