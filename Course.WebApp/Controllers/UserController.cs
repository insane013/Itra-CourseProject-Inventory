using Course.Services.Inventory;
using Course.Models.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Course.Database.Entity.User;
using Course.WebApp.Helpers;
using Course.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Course.WebApp.Controllers;

[Authorize]
[Route("User")]
public class UserController : BaseController
{
    private readonly IInventoryService inventoryService;
    private readonly UserManager<ApplicationUser> userManager;

    public UserController(ILogger<UserController> logger, IInventoryService inventoryService, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    : base(logger, signInManager)
    {
        this.inventoryService = inventoryService;
        this.userManager = userManager;
    }

    [Route("{email}")]
    [RequireUserId]
    public async Task<IActionResult> UserPage()
    {
        var filter = new InventoryFilter { PageNumber = 1, PageSize = 20, CreatedBy = this.UserId };

        var createdInventories = await this.inventoryService.GetFilteredInventoryList(filter);

        filter = new InventoryFilter { PageNumber = 1, PageSize = 20};

        var accessInventories = await this.inventoryService.GetFilteredInventoryList(filter);

        var userPageView = new UserPageView { OwnedInventories = createdInventories, AccessableInventories = accessInventories };

        return this.View(userPageView);
    }
}
