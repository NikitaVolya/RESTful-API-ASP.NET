using AutoMapper;
using RESTful_API_ASP.NET.Models.AutoMapper;
using RESTful_API_ASP.NET.DTO.AutoMapper;


namespace RESTful_API_ASP.NET.Profiles.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Address, AddressDto>();
            CreateMap<AddressDto, Address>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<User, UserShortDto>()
                .ForMember(
                    dest => dest.Address, 
                    opt => opt.MapFrom(
                        src => src.Address.City.ToUpper() + " / " + src.Address.Street
                       )
                );
        }
    }
}
