using System.ComponentModel.DataAnnotations;
using Course.Database.Entity.Chat;
using Course.Database.Entity.User;

namespace Course.Database.Entity.Inventory;

public class InventoryEntity : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string? CreatorId { get; set; } = string.Empty;
    public Guid? CategoryId { get; set; }
    public bool IsPublic { get; set; }

    [Timestamp]
    public required byte[] RowVersion { get; set; }

    public ApplicationUser? Creator { get; set; }
    public Category? Category { get; set; }

    public ICollection<InventoryFieldInfo> CustomFields { get; set; } = new List<InventoryFieldInfo>();
    public ICollection<InventoryItem> Items { get; set; } = new List<InventoryItem>();
    public ICollection<ChatMessage> Chat { get; set; } = new List<ChatMessage>();
    public ICollection<UserAccess> AccessList { get; set; } = new List<UserAccess>();
}
