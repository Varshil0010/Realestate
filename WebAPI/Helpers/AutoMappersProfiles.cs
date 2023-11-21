using AutoMapper;
using WebAPI.DTOS;
using WebAPI.Models;

namespace WebAPI.Helpers
{
    public class AutoMappersProfiles : Profile
    {
        public AutoMappersProfiles()
        {
            CreateMap<City, CityDTO>();
            CreateMap<CityDTO, City>();
        }
    }
}