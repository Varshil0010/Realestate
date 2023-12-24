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
        private readonly IPhotoService photoService;

        public PropertyController(IUnitOfWork uow, IMapper mapper, IPhotoService photoService)
        {
            this.photoService = photoService;
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
            property.PostedBy = userId;
            uow.propertyRepository.AddProperty(property);
            await uow.SaveAsync();
            return StatusCode(201);

        }

        [HttpPost("add/photo/{propId}")]
        [Authorize]
        public async Task<IActionResult> AddPropertyPhoto(IFormFile file, int propId)
        {
            var result = await photoService.UploadPhotoAsync(file);
            if (result.Error != null)
            {
                return BadRequest(result.Error.Message);
            }
            var property = await uow.propertyRepository.GetPropertyIdAsync(propId);

            var photo = new Photo
            {
                ImageUrl = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            if (property.Photos.Count == 0)
            {
                photo.IsPrimary = true;
            }

            property.Photos.Add(photo);
            await uow.SaveAsync();
            return StatusCode(201);
        }


        //property/set-primary-photo/1/bbyywefmjcig
        [HttpPost("set-primary-photo/{propId}/{photoPublicId}")]
        [Authorize]
        public async Task<IActionResult> SetPrimaryPhoto(int propId, string photoPublicId)
        {
            var userId = GetUserId();

            var property = await uow.propertyRepository.GetPropertyIdAsync(propId);

            if (property == null)
                return BadRequest("No such proerty or photo exists");

            if (property.PostedBy != userId)
                return BadRequest("You are not authorised to change the photo");

            var photo = property.Photos.FirstOrDefault(p => p.PublicId == photoPublicId);

            if(photo == null)
                return BadRequest("No such proerty or photo exists");
            
            if(photo.IsPrimary)
                return BadRequest("This is already a primary photo");

            var currentPrimary = property.Photos.FirstOrDefault(p => p.IsPrimary);
            if(currentPrimary != null) currentPrimary.IsPrimary = false;
            photo.IsPrimary = true;

            if(await uow.SaveAsync())
                    return NoContent();

            return BadRequest("Failed to set primary photo");

        }


        [HttpDelete("delete-photo/{propId}/{photoPublicId}")]
        [Authorize]
        public async Task<IActionResult> DeletePhoto(int propId, string photoPublicId)
        {
            var userId = GetUserId();

            var property = await uow.propertyRepository.GetPropertyIdAsync(propId);

            if (property == null)
                return BadRequest("No such proerty or photo exists");

            if (property.PostedBy != userId)
                return BadRequest("You are not authorised to delete the photo");

            var photo = property.Photos.FirstOrDefault(p => p.PublicId == photoPublicId);

            if(photo == null)
                return BadRequest("No such proerty or photo exists");
            
            if(photo.IsPrimary)
                return BadRequest("You cannot delete primary photo");

            var result = await photoService.DeletePhotoAsync(photo.PublicId);
            if(result.Error != null)
                return BadRequest(result.Error.Message);

            property.Photos.Remove(photo);

            if(await uow.SaveAsync())
                    return Ok();

            return BadRequest("Failed to delete photo");

        }
    }
}