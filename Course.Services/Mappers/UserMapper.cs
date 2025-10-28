using AutoMapper;
using Course.Core.Enums;
using Course.Database.Entity;
using Course.Database.Entity.User;
using Course.Models.User;

namespace Task5.WebApi.Services.Mappers;

public class UserMapper: Profile
{
    public UserMapper()
    {
        _ = this.CreateMap<ApplicationUser, User>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(x => x.FullName))
            .ForMember(dest => dest.LastLoginTime, opt => opt.MapFrom(x => x.LastLoginTime))
            .ForMember(dest => dest.RegisterTime, opt => opt.MapFrom(x => x.RegisterTime))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(x => x.Status));

        _ = this.CreateMap<User, ApplicationUser>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(x => x.Email))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(x => x.UserName))
            .ForMember(dest => dest.LastLoginTime, opt => opt.MapFrom(x => x.LastLoginTime))
            .ForMember(dest => dest.RegisterTime, opt => opt.MapFrom(x => x.RegisterTime))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(x => x.Status));

        _ = this.CreateMap<UserRegisterDto, ApplicationUser>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(x => x.Email))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(x => x.UserName))
            .ForMember(dest => dest.RegisterTime, opt => opt.MapFrom(x => DateTime.UtcNow))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(x => UserStatus.Unverified));
    }
}
