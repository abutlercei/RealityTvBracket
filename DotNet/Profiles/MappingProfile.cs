using AutoMapper;
using DotNet.Models;
using DotNet.Models.ViewModels;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Pool, PoolSearchResultViewModel>()
            .ForMember(dest => dest.PoolId,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.PoolName,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.HostUsername,
                opt => opt.MapFrom(src => src.UserProfile != null
                    ? src.UserProfile.Username : string.Empty));
        CreateMap<PoolMember, MemberTableViewModel>()
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.UsernameFK))
            .ForMember(dest => dest.UserPreferredName,
                opt => opt.MapFrom(src => src.UserProfile != null
                    ? src.UserProfile.Name : string.Empty));
    }
}