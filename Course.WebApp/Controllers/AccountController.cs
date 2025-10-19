using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Course.Database.Entity.User;
using Course.Models.User;
using Course.Services.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Course.WebApp.Controllers;

[Route("Account")]
public class AccountController : BaseController
{

    private readonly IAuthenticationService authService;

    public AccountController(IAuthenticationService authService, SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger)
    : base(logger, signInManager)
    {
        this.authService = authService;
    }

    [Route("Login")]
    [HttpGet]
    public IActionResult Login()
    {
        return this.View();
    }

    [Route("Login")]
    [HttpPost]
    public async Task<IActionResult> Login(UserLoginDto model)
    {
        return await this.AccessDeniedProceed(async () =>
        {
            if (await this.authService.LoginUser(model))
            {
                this.TempData["Success"] = "Login success..";
                return this.RedirectToAction("Index", controllerName: "Inventory");
            }

            this.TempData["Error"] = "Incorrect email or password.";
            return this.View(model);
        });
    }

    [Route("Logout")]
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await this.authService.LogOutUser();

        this.TempData["Success"] = "User logged out.";
        return this.RedirectToAction("Login", controllerName: "Account");
    }

    [Route("Register")]
    [HttpGet]
    public IActionResult Register()
    {
        return this.View();
    }

    [Route("Register")]
    [HttpPost]
    public async Task<IActionResult> Register([FromForm] UserRegisterDto user)
    {
        if (!this.ValidateModel(out IList<string> errors))
        {
            this.TempData["Errors"] = errors;
            return this.View(user);
        }

        var result = await this.authService.RegisterUser(user, this.GetActionUrl("ConfirmEmail", "Account"));

        this.TempData["Errors"] = result.Errors;
        
        if (result.Succeeded) this.TempData["Success"] = "User registered successfully.";

        return result.Succeeded ? this.RedirectToAction("Index", controllerName: "Inventory") : this.View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }

    private string GetActionUrl(string action, string controller)
    {
        var url = Url.Action(
            action: action,
            controller: controller,
            values: null,
            protocol: HttpContext.Request.Scheme,
            host: HttpContext.Request.Host.ToString())
                ?? $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/{controller}/{action}";

        return url;
    }
}