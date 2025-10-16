using System.ComponentModel.DataAnnotations;
using Course.Database.Entity.Chat;
using Course.Database.Entity.Inventory;
using Microsoft.AspNetCore.Identity;

namespace Course.Database.Entity.User;

public class ApplicationUser : IdentityUser
{
    public ICollection<UserAccess> AccessList { get; set; } = new List<UserAccess>();
    public ICollection<InventoryEntity> CreatedInventories { get; set; } = new List<InventoryEntity>();
    public ICollection<ChatMessage> Messages { get; set; } = new List<ChatMessage>();
    public ICollection<UserLikes> Likes { get; set; } = new List<UserLikes>();
}
