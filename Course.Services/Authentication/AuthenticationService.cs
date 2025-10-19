using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Course.Database.Entity;
using Course.Models.User;
using Course.Core.Exceptions;
using Course.Services.Logging;
using Course.Database.Entity.User;
using Course.Core.Enums;

namespace Course.Services.Authentication;

public class AuthenticationService : BaseService, IAuthenticationService
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly SignInManager<ApplicationUser> signInManager;

    public AuthenticationService(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 IMapper mapper, ILogger<AuthenticationService> logger)
    : base(mapper, logger)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    public async Task<AuthenticationResult> RegisterUser(UserRegisterDto model, string confirmActionUrl)
    {
        RegistrationLogs.UserRegistrationStart(this._logger, model.Email);

        ApplicationUser user = this.mapper.Map<ApplicationUser>(model);
        var res = await this.userManager.CreateAsync(user, model.UserPassword);

        return await this.RegistrationResultProceed(res, model.Email, confirmActionUrl);
    }

    public async Task<bool> LoginUser(UserLoginDto model)
    {
        var user = await this.userManager.FindByEmailAsync(model.Email);

        if (user is null) return false;

        var result = await this.signInManager.PasswordSignInAsync(user, model.UserPassword, model.RememberMe, lockoutOnFailure: false);

        if (result.Succeeded) await this.UpdateUserLoginTime(user);

        return result.Succeeded;
    }

    public async Task LogOutUser()
    {
        await this.signInManager.SignOutAsync();
    }

    private async Task UpdateUserStatus(ApplicationUser user, UserStatus status)
    {
        if (user.Status != UserStatus.Blocked)
        {
            user.Status = status;
            await this.userManager.UpdateAsync(user);
        }
    }

    private async Task UpdateUserLoginTime(ApplicationUser user)
    {
        user.LastLoginTime = DateTime.UtcNow;
        await this.userManager.UpdateAsync(user);
    }

    private async Task<AuthenticationResult> RegistrationResultProceed(IdentityResult result, string userEmail, string confirmActionUrl)
    {
        return result.Succeeded ? await this.RegistractionSuccess(userEmail, confirmActionUrl) : this.RegistractionFail(result, userEmail);
    }
    
    private async Task<AuthenticationResult> RegistractionSuccess(string userEmail, string confirmActionUrl)
    {
        RegistrationLogs.UserRegistrationSuccess(this._logger, userEmail);

        var createdUser = await this.userManager.FindByEmailAsync(userEmail);

        await this.signInManager.SignInAsync(createdUser!, true);
        await this.UpdateUserLoginTime(createdUser!);

        return AuthenticationResult.Success;
    }

    private AuthenticationResult RegistractionFail(IdentityResult result, string userEmail)
    {
        RegistrationLogs.UserRegistrationFailed(this._logger, userEmail);

        AuthenticationResult response = new AuthenticationResult { Succeeded = false };

        foreach (var error in result.Errors)
        {
            CommonLogs.LogWarningMessage(this._logger, error.Description);

            response.Errors.Add(error.Description);
        }

        CommonLogs.LogWarningMessage(this._logger, $"Errors total: {response.Errors.Count()}");

        return response;
    }
}