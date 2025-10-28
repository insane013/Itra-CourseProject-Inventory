using Course.Core;
using Course.Models.Inventory;
using Course.Models.User;

namespace Course.Services.Inventory;

public interface IUserService
{
    public Task<User> GetUserById(string id);
    public Task<User> GetUserByEmail(string email);
}