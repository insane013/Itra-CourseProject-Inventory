using System.ComponentModel.DataAnnotations;

namespace Course.Database.Entity;

public class Inventory
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string CreatorId { get; set; } = string.Empty;
    public int? CategoryId { get; set; }
    public bool IsPublic { get; set; }

    [Timestamp]
    public required byte[] RowVersion { get; set; }

    public ApplicationUser? Creator { get; set; }

    public ICollection<InventoryFieldInfo>? CustomFields { get; set; }
    public ICollection<InventoryItem>? Items { get; set; }
    public ICollection<ChatMessage>? Chat { get; set; }
    public ICollection<UserAccess>? AccessList { get; set; }
}
