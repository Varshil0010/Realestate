using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Data.Repo;
using WebAPI.DTOS;
using WebAPI.Interfaces;
using WebAPI.Models;
//using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public CityController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await uow.CityRepository.GetCitiesAsync();

            var citiesDto = mapper.Map<IEnumerable<CityDTO>>(cities);
            return Ok(citiesDto);
        }

        [HttpPost("post")]
        public async Task<IActionResult> AddCity(CityDTO cityDTO)
        {
            var city = new City{
                Name = cityDTO.Name,
                Country = cityDTO.Country,
                LastUpdateBy = 1,
                LastUpdateOn = DateTime.Now
            };
            uow.CityRepository.AddCity(city);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCity(int id, CityDTO cityDTO)
        {
            var city = await uow.CityRepository.FindCity(id);
            city.LastUpdateBy = 1;
            city.LastUpdateOn = DateTime.Now;
            mapper.Map(cityDTO, city);
            await uow.SaveAsync();

            return StatusCode(200);
        }

        [HttpPut("updateCityName/{id}")]
        public async Task<IActionResult> UpdateCity(int id, CityUpdateDTO cityUpdateDTO)
        {
            var city = await uow.CityRepository.FindCity(id);
            city.LastUpdateBy = 1;
            city.LastUpdateOn = DateTime.Now;
            mapper.Map(cityUpdateDTO, city);
            await uow.SaveAsync();

            return StatusCode(200);
        }

        [HttpPatch("update/{id}")]
        public async Task<IActionResult> UpdateCityPatch(int id, JsonPatchDocument<City> cityPatch)
        {
            var city = await uow.CityRepository.FindCity(id);
            city.LastUpdateBy = 1;
            city.LastUpdateOn = DateTime.Now;
            cityPatch.ApplyTo(city, ModelState);
            await uow.SaveAsync();

            return StatusCode(200);
        }
        
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.CityRepository.DeleteCity(id);
            await uow.SaveAsync();
            return StatusCode(200);
        }
    }
}