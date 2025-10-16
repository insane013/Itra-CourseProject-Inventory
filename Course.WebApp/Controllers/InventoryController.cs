using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Course.Database.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Course.WebApp.Controllers;

[Route("Inventory")]
public class InventoryController : Controller
{
    private readonly ILogger<InventoryController> _logger;
    private readonly IInventoryRepository inventoryService;

    public InventoryController(ILogger<InventoryController> logger, IInventoryRepository inventoryService)
    {
        _logger = logger;
        this.inventoryService = inventoryService;
    }

    public async Task<IActionResult> Index()
    {
        var res = await this.inventoryService.GetAll();
        return View(res);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
