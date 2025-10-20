using AutoMapper;
using RESTful_API_ASP.NET.Models.AutoMapper;
using RESTful_API_ASP.NET.DTO.AutoMapper;


namespace RESTful_API_ASP.NET.Profiles.AutoMapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.TotalItems, opt => opt.MapFrom(src => src.Items.Count()))
                .ForMember(dest => dest.ProductNames, opt => opt.MapFrom(src => src.Items.Select(i => i.ProductName)))
                .ReverseMap()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src =>
                    src.ProductNames.Select(p => new OrderItem
                    {
                        ProductName = p,
                        Quantity = 1
                    })
                ));
        }
    }
}
