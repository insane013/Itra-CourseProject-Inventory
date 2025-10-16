using System.ComponentModel.DataAnnotations;

namespace Course.Database.Entity.Inventory;

public class Category : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public ICollection<InventoryEntity> Inventories { get; set; } = new List<InventoryEntity>();
}
