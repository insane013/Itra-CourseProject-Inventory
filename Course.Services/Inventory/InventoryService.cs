using System.Threading.Tasks;
using AutoMapper;
using Course.Core;
using Course.Database.Repository.Interfaces;
using Course.Models.Inventory;
using Course.Services.Mapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Course.Services.Inventory;

public class InventoryService : BaseService, IInventoryService
{
    private readonly IInventoryRepository repository;

    public InventoryService(IInventoryRepository repository, IMapper mapper, ILogger<InventoryService> logger)
    : base(mapper, logger)
    {
        this.repository = repository;
    }

    async Task<PaginatedResult<InventoryCommonView>> IInventoryService.GetFullInventoryList(InventoryFilter filter)
    {
        var inventories = await this.repository.GetAll();

        inventories = inventories.OrderBy(x => x.Title);

        return PaginationHelper.Paginate(
            inventories,
            filter.PageNumber,
            filter.PageSize,
            x => this.mapper.Map<InventoryCommonView>(x)
        );
    }
}