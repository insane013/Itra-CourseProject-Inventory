using Course.Database.Entity.Inventory;

namespace Course.Database.Repository.Interfaces;

public interface IInventoryRepository : IRepository<InventoryEntity>
{
    public IQueryable<InventoryEntity> GetAll();
}
