using System.ComponentModel.DataAnnotations;
using Course.Database.Entity.User;

namespace Course.Database.Entity.Inventory;

public class InventoryItem : BaseEntity
{
    public Guid InventoryId { get; set; }
    public string CustomId { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; } = string.Empty;

    [Timestamp]
    public required byte[] RowVersion { get; set; }
    
    public ICollection<InventoryFieldValue> CustomFieldValues { get; set; } = new List<InventoryFieldValue>();
    public ICollection<UserLikes> Likes { get; set; } = new List<UserLikes>();
    public InventoryEntity? Inventory { get; set; }
    public ApplicationUser? User { get; set; }
}
