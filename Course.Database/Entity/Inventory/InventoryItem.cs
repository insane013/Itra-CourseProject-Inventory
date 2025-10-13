using System.ComponentModel.DataAnnotations;

namespace Course.Database.Entity;

public class InventoryItem
{
    public int Id { get; set; }
    public int InventoryId { get; set; }
    public string CustomId { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; } = string.Empty;

    [Timestamp]
    public required byte[] RowVersion { get; set; }
    
    public ICollection<InventoryFieldValue>? CustomFields { get; set; }
    public ICollection<UserLikes>? Likes { get; set; }
    public Inventory? Inventory { get; set; }
    public ApplicationUser? User { get; set; }
}
