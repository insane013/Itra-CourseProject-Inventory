namespace Course.Database.Entity;

public class ChatMessage : BaseEntity
{
    public Guid InventoryId { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public string Message { get; set; } = string.Empty;
    
    public Inventory? Inventory { get; set; }
    public ApplicationUser? User { get; set; }
}
