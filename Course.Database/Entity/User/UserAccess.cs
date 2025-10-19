using System.ComponentModel.DataAnnotations;
using Course.Core.Enums;
using Course.Database.Entity.Inventory;

namespace Course.Database.Entity.User;

public class UserAccess
{
    public required string InventoryId { get; set; }
    public required string UserId { get; set; }
    public AccessLevel AccessLevel { get; set; }

    [ConcurrencyCheck]
    public Guid Version { get; set; }

    public InventoryEntity? Inventory { get; set; }
    public ApplicationUser? User { get; set; }
}
