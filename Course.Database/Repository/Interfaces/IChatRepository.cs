using Course.Database.Entity;

namespace Course.Database.Repository.Interfaces;

public interface IChatRepository : IRepository<ChatMessage>
{
    public Task<IEnumerable<ChatMessage>> GetFromInventory(Guid InventoryId);
}
