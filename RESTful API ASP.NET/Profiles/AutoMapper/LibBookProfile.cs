using AutoMapper;
using RESTful_API_ASP.NET.Models.Authorisation;
using RESTful_API_ASP.NET.DTO.Authorisation;


namespace RESTful_API_ASP.NET.Profiles.AutoMapper
{
    public class LibBookProfile : Profile
    {
        public LibBookProfile()
        {
            CreateMap<LibBookDto, LibBookModel>();
            CreateMap<LibBookModel, LibBookDto>();
        }
    }
}
