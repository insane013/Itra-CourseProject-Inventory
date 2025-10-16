using Course.Database.Entity;

namespace Course.Database.Repository.Interfaces;

public interface IInventoryRepository : IRepository<Inventory>
{
    public Task<IEnumerable<Inventory>> GetAll();
}
