using Course.Database.Entity.Inventory;

namespace Course.Database.Repository.Interfaces;

public interface IFieldInfoRepository : IRepository<InventoryFieldInfo>
{
    public Task<IEnumerable<InventoryFieldInfo>> GetFromInventory(string InventoryId);
}
