using Course.Database.Entity.Chat;

namespace Course.Database.Repository.Interfaces;

public interface IChatRepository : IRepository<ChatMessage>
{
    public Task<IEnumerable<ChatMessage>> GetFromInventory(string InventoryId);
}
