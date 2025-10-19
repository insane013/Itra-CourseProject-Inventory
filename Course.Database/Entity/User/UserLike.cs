using Course.Database.Entity.Inventory;

namespace Course.Database.Entity.User;

public class UserLikes
{
    public required string InventoryItemId { get; set; }
    public required string UserId { get; set; }
    public DateTime CreatedAt { get; set; }

    public InventoryItem? Item { get; set; }
    public ApplicationUser? User { get; set; }
}
