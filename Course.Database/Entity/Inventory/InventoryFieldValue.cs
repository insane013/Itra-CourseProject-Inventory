using System.ComponentModel.DataAnnotations;

namespace Course.Database.Entity;

public class InventoryFieldValue : BaseEntity
{
    public Guid InventoryItemId { get; set; }
    public Guid FieldInfoId { get; set; }
    public string? Value { get; set; }

    [Timestamp]
    public required byte[] RowVersion { get; set; }

    public InventoryItem? InventoryItem { get; set; }
    public InventoryFieldInfo? Field { get; set; }
}
