using Course.Services.Inventory;
using Course.Models.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Course.Database.Entity.User;
using Course.WebApp.Helpers;
using Course.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Course.Core.Enums;

namespace Course.WebApp.Controllers;

[Authorize]
[Route("Inventory")]
public class InventoryController : BaseController
{
    private readonly IInventoryService inventoryService;

    public InventoryController(ILogger<InventoryController> logger, IInventoryService inventoryService, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    : base(logger, signInManager)
    {
        this.inventoryService = inventoryService;
    }

    [Route("")]
    public async Task<IActionResult> Index()
    {
        var res = await this.inventoryService.GetFilteredInventoryList(new InventoryFilter { PageNumber = 1, PageSize = 20 });
        var dash = new DashboardView { RecentInventories = res.Items, TopInventories = res.Items };
        return View(dash);
    }

    [HttpGet]
    [Route("Create")]
    public async Task<IActionResult> Create()
    {
        return this.View(new InventoryCreateDto());
    }

    [HttpPost]
    [Route("Create")]
    [RequireUserId]
    public async Task<IActionResult> Create(InventoryCreateDto model)
    {
        this.Logger.LogInformation($"Create inventory: {model.ToString()}");

        await this.inventoryService.CreateInventory(this.UserId, model);

        return this.RedirectToAction("Index", controllerName: "Inventory");
    }
}
