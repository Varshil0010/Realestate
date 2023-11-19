using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Data.Repo;
using WebAPI.Models;
//using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository cityRepository;
        public CityController(CityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await cityRepository.GetCitiesAsync();
            return Ok(cities);
        }

        [HttpPost("post")]
        public async Task<IActionResult> AddCity(City city)
        {
            cityRepository.AddCity(city);
            await cityRepository.SaveAsync();
            return StatusCode(201);
        }
        
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            cityRepository.DeleteCity(id);
            await cityRepository.SaveAsync();
            return StatusCode(200);
        }
    }
}