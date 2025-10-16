using Course.Database.Entity.Inventory;

namespace Course.Database.Entity.User;

public class UserLikes
{
    public Guid InventoryItemId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public InventoryItem? Item { get; set; }
    public ApplicationUser? User { get; set; }
}
