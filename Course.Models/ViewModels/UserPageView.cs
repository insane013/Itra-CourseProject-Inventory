using Course.Core;
using Course.Models.Inventory;

namespace Course.Models.ViewModels;

public class UserPageView
{
    public PaginatedResult<InventoryCommonView> OwnedInventories { get; set; } = PaginatedResult<InventoryCommonView>.Empty();
    public PaginatedResult<InventoryCommonView> AccessableInventories { get; set; } = PaginatedResult<InventoryCommonView>.Empty();
}
