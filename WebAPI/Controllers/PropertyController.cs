using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOS;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PropertyController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public PropertyController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;

        }

        [HttpGet("list/{sellRent}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPropertyList(int sellRent)
        {
            var properties = await uow.propertyRepository.GetPropertiesAsync(sellRent);
            var propertyListDTO = mapper.Map<IEnumerable<PropertyListDTO>>(properties);
            return Ok(propertyListDTO);
        }

        [HttpGet("detail/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPropertyDetail(int id)
        {
            var property = await uow.propertyRepository.GetPropertyDetailAsync(id);
            var propertyDTO = mapper.Map<PropertyDetailDTO>(property);
            return Ok(propertyDTO);
        }


        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> AddProperty(PropertyDTO propertyDTO)
        {

                var property = mapper.Map<Property>(propertyDTO);
                var userId = GetUserId();
                property.PostedBy = 1;
                uow.propertyRepository.AddProperty(property);
                await uow.SaveAsync();
                return StatusCode(201);

        }
    }
}