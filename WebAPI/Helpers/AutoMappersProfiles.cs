using AutoMapper;
using WebAPI.DTOS;
using WebAPI.Models;

namespace WebAPI.Helpers
{
    public class AutoMappersProfiles : Profile
    {
        public AutoMappersProfiles()
        {
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<City, CityUpdateDTO>().ReverseMap();
            CreateMap<Property, PropertyListDTO>()
                .ForMember(d => d.City, opt => opt.MapFrom(src => src.City.Name))
                .ForMember(d => d.Country, opt => opt.MapFrom(src => src.City.Country))
                .ForMember(d => d.FurnishingType, opt => opt.MapFrom(src => src.FurnishingType.Name))
                .ForMember(d => d.PropertyType, opt => opt.MapFrom(src => src.PropertyType.Name));
        }
    }
}