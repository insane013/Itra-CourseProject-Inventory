using Course.Models.User;

namespace Course.Services.Authentication;

public interface IAuthenticationService
{
    public Task<bool> LoginUser(UserLoginDto model);
    public Task LogOutUser();
    public Task<AuthenticationResult> RegisterUser(UserRegisterDto user, string confirmActionUrl);
}