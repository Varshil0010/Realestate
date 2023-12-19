using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOS;
using WebAPI.Interfaces;

namespace WebAPI.Controllers
{
    public class PropertyTypeController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public PropertyTypeController(IUnitOfWork uow, IMapper mapper)
        {
            this.mapper = mapper;
            this.uow = uow;

        }


        [HttpGet("list")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPropertyTypes()
        {
            var PropertyTypes = await uow.propertyTypeRepository.GetPropertyTypesAsync();
            var PropertyTypeDto = mapper.Map<IEnumerable<KeyValuePairDto>>(PropertyTypes);
            return Ok(PropertyTypeDto);
        }
    }
}