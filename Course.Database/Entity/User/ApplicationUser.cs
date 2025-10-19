using System.ComponentModel.DataAnnotations;
using Course.Core.Enums;
using Course.Database.Entity.Chat;
using Course.Database.Entity.Inventory;
using Microsoft.AspNetCore.Identity;

namespace Course.Database.Entity.User;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
    public UserStatus Status { get; set; }
    public DateTime LastLoginTime;
    public DateTime RegisterTime;
    public ICollection<UserAccess> AccessList { get; set; } = new List<UserAccess>();
    public ICollection<InventoryEntity> CreatedInventories { get; set; } = new List<InventoryEntity>();
    public ICollection<ChatMessage> Messages { get; set; } = new List<ChatMessage>();
    public ICollection<UserLikes> Likes { get; set; } = new List<UserLikes>();
}
