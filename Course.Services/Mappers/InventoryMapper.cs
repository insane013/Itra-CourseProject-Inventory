using AutoMapper;
using Course.Database.Entity;
using Course.Database.Entity.Inventory;
using Course.Models.Inventory;

namespace Course.Services.Mappers;

public class InventoryMapper: Profile
{
    public const string NullReferencePlaceholder = "<Deleted>";
    public InventoryMapper()
    {
        _ = this.CreateMap<InventoryEntity, InventoryCommonView>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(x => x.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(x => x.Description))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(x => x.ImageUrl))
            .ForMember(dest => dest.IsPublic, opt => opt.MapFrom(x => x.IsPublic))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(x => x.CreatedAt))
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(x => x.CategoryId))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(x => x.Category != null ? x.Category.Title : NullReferencePlaceholder))
            .ForMember(dest => dest.CreatorId, opt => opt.MapFrom(x => x.CreatorId))
            .ForMember(dest => dest.CreatorName, opt => opt.MapFrom(x => x.Creator != null ? x.Creator.UserName : NullReferencePlaceholder));

        _ = this.CreateMap<InventoryCreateDto, InventoryEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(x => Guid.NewGuid().ToString()))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(x => x.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(x => x.Description))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(x => x.ImageUrl))
            .ForMember(dest => dest.IsPublic, opt => opt.MapFrom(x => x.IsPublic))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(x => x.CreatedAt))
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(x => "a80b04f2-7732-48a0-ae9a-7bc58b156a6c"))
            .ForMember(dest => dest.Version, opt => opt.MapFrom(x => Guid.NewGuid()))
            .ForMember(dest => dest.CreatorId, opt => opt.MapFrom(x => x.CreatedBy));
    }
}
