using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Course.Database.Entity;

public class ApplicationUser : IdentityUser
{
    public ICollection<UserAccess>? AccessList { get; set; }
    public ICollection<Inventory>? CreatedInventories { get; set; }
    public ICollection<ChatMessage>? Messages { get; set; }
    public ICollection<UserLikes>? Likes { get; set; }
}
