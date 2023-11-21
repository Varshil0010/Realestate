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
        }
    }
}