using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Interfaces;

namespace WebAPI.Controllers
{
    public class PropertyController : BaseController
    {
        private readonly IUnitOfWork uow;


        public PropertyController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpGet("type/{sellRent}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPropertyList(int sellRent)
        {
            var properties = await uow.propertyRepository.GetPropertiesAsync(sellRent);
            return Ok(properties);
        }
    }
}