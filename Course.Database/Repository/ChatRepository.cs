using Course.Database.Entity.Chat;
using Course.Database.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Course.Database.Repository;

public class ChatRepository : BaseRepository<ChatMessage>, IChatRepository
{
    public ChatRepository(InventoryDbContext context)
        : base(context, context.ChatMessages)
    {

    }

    public async Task<IEnumerable<ChatMessage>> GetFromInventory(string InventoryId)
    {
        return await this._dbSet
                    .Where(ii => ii.InventoryId == InventoryId)
                    .Include(ii => ii.User)
                    .Include(ii => ii.Inventory)
                    .AsNoTracking()
                    .ToListAsync();
    }

    public override async Task<ChatMessage?> GetById(string id)
    {
        return await this._dbSet
            .Include(ii => ii.User)
            .Include(ii => ii.Inventory)
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == id);
    }
}
