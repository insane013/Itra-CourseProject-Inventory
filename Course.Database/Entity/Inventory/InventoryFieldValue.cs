using System.ComponentModel.DataAnnotations;

namespace Course.Database.Entity;

public class InventoryFieldValue
{
    public int Id { get; set; }
    public int InventoryItemId { get; set; }
    public int FieldInfoId { get; set; }
    public string? Value { get; set; }

    [Timestamp]
    public required byte[] RowVersion { get; set; }

    public InventoryItem? InventoryItem { get; set; }
    public InventoryFieldInfo? Field { get; set; }
}
