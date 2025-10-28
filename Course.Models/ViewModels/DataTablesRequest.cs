using Course.Core.Enums;
using Course.Models.Inventory;

namespace Course.Models.ViewModels;

public class DataTablesRequest
{
    public int start { get; set; }
    public int length { get; set; }
    public string? search { get; set; }
    public string? sortCol { get; set; }
    public SortDirections sortDir { get; set; }
    public string? draw { get; set; }
    public int pageNumber => (start / length) + 1;
}
