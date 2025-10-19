using System.ComponentModel.DataAnnotations;

namespace Course.Database.Entity.Inventory;

public class InventoryFieldValue : BaseEntity
{
    public required string InventoryItemId { get; set; }
    public required string FieldInfoId { get; set; }
    public string? Value { get; set; }

    [ConcurrencyCheck]
    public Guid Version { get; set; }

    public InventoryItem? InventoryItem { get; set; }
    public InventoryFieldInfo? Field { get; set; }
}
