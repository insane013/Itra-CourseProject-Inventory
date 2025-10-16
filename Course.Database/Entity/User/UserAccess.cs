using System.ComponentModel.DataAnnotations;
using Course.Core.Enums;
using Course.Database.Entity.Inventory;

namespace Course.Database.Entity.User;

public class UserAccess
{
    public Guid InventoryId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public AccessLevel AccessLevel { get; set; }

    [Timestamp]
    public required byte[] RowVersion { get; set; }

    public InventoryEntity? Inventory { get; set; }
    public ApplicationUser? User { get; set; }
}
