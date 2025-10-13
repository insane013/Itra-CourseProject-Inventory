using System.ComponentModel.DataAnnotations;
using Course.Core.Enums;

namespace Course.Database.Entity;

public class UserLikes
{
    public int InventoryItemId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public InventoryItem? Item { get; set; }
    public ApplicationUser? User { get; set; }
}
