using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Course.Database.Entity;

public class ApplicationUser : IdentityUser
{
    public ICollection<UserAccess> AccessList { get; set; } = new List<UserAccess>();
    public ICollection<Inventory> CreatedInventories { get; set; } = new List<Inventory>();
    public ICollection<ChatMessage> Messages { get; set; } = new List<ChatMessage>();
    public ICollection<UserLikes> Likes { get; set; } = new List<UserLikes>();
}
