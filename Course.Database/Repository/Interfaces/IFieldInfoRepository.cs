using Course.Database.Entity;

namespace Course.Database.Repository.Interfaces;

public interface IFieldInfoRepository : IRepository<InventoryFieldInfo>
{
    public Task<IEnumerable<InventoryFieldInfo>> GetFromInventory(Guid InventoryId);
}
