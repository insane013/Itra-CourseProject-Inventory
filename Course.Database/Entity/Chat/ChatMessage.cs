using Course.Database.Entity.Inventory;
using Course.Database.Entity.User;

namespace Course.Database.Entity.Chat;

public class ChatMessage : BaseEntity
{
    public Guid InventoryId { get; set; }
    public string? CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public string Message { get; set; } = string.Empty;
    
    public InventoryEntity? Inventory { get; set; }
    public ApplicationUser? User { get; set; }
}
