using Course.Core.Enums;

namespace Course.Models.Inventory;

public class InventoryFilter : BaseFilter
{
    public string? CreatedBy { get; set; }
    public string? AccessableBy { get; set; }

    public string? Search { get; set; }
    public string? SortColumn { get; set; }
    public SortDirections SortDirection { get; set; } = SortDirections.Asc;
}
