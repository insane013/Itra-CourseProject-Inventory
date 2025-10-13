using System.ComponentModel.DataAnnotations;

namespace Course.Database.Entity;

public class InventoryFieldInfo
{
    public int Id { get; set; }
    public int InventoryId { get; set; }
    public string FieldName { get; set; } = string.Empty;
    public string FieldType { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string FieldDescription { get; set; } = string.Empty;
    public bool IsShown { get; set; }

    [Timestamp]
    public required byte[] RowVersion { get; set; }

    public Inventory? Inventory { get; set; }
}
