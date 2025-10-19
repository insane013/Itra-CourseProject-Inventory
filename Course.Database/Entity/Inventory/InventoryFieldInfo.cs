using System.ComponentModel.DataAnnotations;

namespace Course.Database.Entity.Inventory;

public class InventoryFieldInfo : BaseEntity
{
    public required string InventoryId { get; set; }
    public string FieldName { get; set; } = string.Empty;
    public string FieldType { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string FieldDescription { get; set; } = string.Empty;
    public bool IsShown { get; set; }

    [ConcurrencyCheck]
    public Guid Version { get; set; }

    public InventoryEntity? Inventory { get; set; }
}
