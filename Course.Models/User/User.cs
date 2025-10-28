using Course.Core.Enums;

namespace Course.Models.User;

public class User
{
    public string Id { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public UserStatus Status { get; set; } = UserStatus.Unverified; // EXTRACT DEFAULTS
    public DateTime LastLoginTime { get; set; }
    public DateTime RegisterTime { get; set; }
    public string UserName { get; set; } = string.Empty;
}