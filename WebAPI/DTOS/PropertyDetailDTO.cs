using WebAPI.DTOS;

namespace WebAPI.DTOS
{
    public class PropertyDetailDTO : PropertyListDTO
    {
        public int CarpetArea { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public int FloorNo { get; set; }    
        public int TotalFloors { get; set; }
        public int Security { get; set; }
        public int Maintenance { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
    }
}