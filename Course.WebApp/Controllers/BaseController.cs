using Course.Core.Exceptions;
using Course.Database.Entity.User;
using Course.Services.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Course.WebApp.Controllers;

public abstract class BaseController : Controller
{
    protected readonly ILogger<BaseController> Logger;
    private readonly SignInManager<ApplicationUser> signInManager;

    protected BaseController(ILogger<BaseController> logger, SignInManager<ApplicationUser> signInManager)
    {
        this.Logger = logger;
        this.signInManager = signInManager;
    }

    protected string? UserId
    {
        get => this.HttpContext?.Items["UserId"]?.ToString();
    }

    /// <summary>
    /// Gets Id of currently authorized user.
    /// </summary>
    /// <returns>User ID.</returns>
    /// <exception cref="UnauthorizedAccessException">Throws if there is no authorized users.</exception>
    protected string GetUserIdOrThrow()
    {
        var userId = this.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
        {
            CommonLogs.LogWarningMessage(this.Logger, $"Unauthorized user access.");
            throw new UnauthorizedAccessException("Unauthorized user access.");
        }

        return userId;
    }

    protected async Task<IActionResult> AccessDeniedProceed(Func<Task<IActionResult>> func)
    {
        try
        {
            return await func.Invoke();
        }
        catch (AccessDeniedException)
        {
            CommonLogs.LogWarningMessage(this.Logger, "Unauthorized user access.");
            await this.signInManager.SignOutAsync();
            this.TempData["Error"] = "Your account is currently blocked.";
            return this.Forbid();
        }
    }

    protected bool ValidateModel(out IList<string> errors)
    {
        if (!this.ModelState.IsValid)
        {
            errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            return false;
        }
        errors = Enumerable.Empty<string>().ToList();
        return true;
    }
}