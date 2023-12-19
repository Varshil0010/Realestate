using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOS;
using WebAPI.Interfaces;

namespace WebAPI.Controllers
{
    public class FurnishingTypeController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public FurnishingTypeController(IUnitOfWork uow, IMapper mapper)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("list")]
        [AllowAnonymous]

        public async Task<IActionResult> GetFurnishingType()
        {
            var FurnishingTypes = await uow.furnishingTypeRepository.GetFurnishingTypesAsync();
            var FurnishingTypeDto = mapper.Map<IEnumerable<KeyValuePairDto>>(FurnishingTypes);
            return Ok(FurnishingTypeDto);
        }
    }
}