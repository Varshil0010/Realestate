namespace WebAPI.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime LastUpdateOn { get; set; }
        public int LastUpdateBy { get; set; }

    }
}