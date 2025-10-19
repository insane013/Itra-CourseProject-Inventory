using Course.Core.Enums;

namespace Course.Models.User;

public class User
{
    public string Email = string.Empty;
    public UserStatus Status = UserStatus.Unverified; // EXTRACT DEFAULTS
    public DateTime LastLoginTime;
    public DateTime RegisterTime;
    public string UserName = string.Empty;
}