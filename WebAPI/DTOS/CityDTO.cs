using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOS
{
    public class CityDTO
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "City Name is mandatory field")]
        [StringLength(50, MinimumLength =2, ErrorMessage ="City name must be a minimum length of 2")]
        [RegularExpression(".*[a-zA-Z]+.*", ErrorMessage = "City name must be in a string")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Country Name is mandatory field")]
        [StringLength(50, MinimumLength =2, ErrorMessage ="Country name must be a minimum length of 2")]
        [RegularExpression(".*[a-zA-Z]+.*", ErrorMessage = "Country name must be in a string")]
        public string Country { get; set; }
    }
}