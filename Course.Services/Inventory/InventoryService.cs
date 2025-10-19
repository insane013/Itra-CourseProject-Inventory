using System.Threading.Tasks;
using AutoMapper;
using Course.Core;
using Course.Core.Exceptions;
using Course.Database.Entity.Inventory;
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

    async Task<InventoryCommonView?> IInventoryService.CreateInventory(string? currentUserId, InventoryCreateDto model)
    {
        await this.CheckUserAccess(currentUserId);

        var entity = this.mapper.Map<InventoryEntity>(model);

        this._logger.LogWarning($"Category: {entity.CategoryId}");
        this._logger.LogWarning($"User: {entity.CreatorId}");

        var res = await this.repository.Add(entity);

        return this.mapper.Map<InventoryCommonView>(res);
    }

    private async Task CheckUserAccess(string? userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            // throw new AccessDeniedException("You have to login to non-blocked account to use the app.");
        }

        // implement in dedicated service
    }
}