using System.ComponentModel.DataAnnotations;

namespace Course.Database.Entity;

public class Category : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
