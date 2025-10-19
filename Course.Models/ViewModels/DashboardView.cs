using Course.Models.Inventory;

namespace Course.Models.ViewModels;

public class DashboardView
{
    public IEnumerable<InventoryCommonView> RecentInventories { get; set; } = Enumerable.Empty<InventoryCommonView>();
    public IEnumerable<InventoryCommonView> TopInventories { get; set; } = Enumerable.Empty<InventoryCommonView>();
    public IEnumerable<InventoryCommonView> TagCloud { get; set; } = Enumerable.Empty<InventoryCommonView>();
}
