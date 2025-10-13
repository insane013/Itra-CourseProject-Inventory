using System.ComponentModel.DataAnnotations;
using Course.Core.Enums;

namespace Course.Database.Entity;

public class UserAccess
{
    public int InventoryId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public AccessLevel AccessLevel { get; set; }

    [Timestamp]
    public required byte[] RowVersion { get; set; }

    public Inventory? Inventory { get; set; }
    public ApplicationUser? User { get; set; }
}
