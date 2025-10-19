using Course.Core;
using Course.Models.Inventory;

namespace Course.Services.Inventory;

public interface IInventoryService
{
    public Task<PaginatedResult<InventoryCommonView>> GetFullInventoryList(InventoryFilter filter);

    public Task<InventoryCommonView?> CreateInventory(string? currentUserId, InventoryCreateDto model);
}