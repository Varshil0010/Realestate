namespace WebAPI.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime LastUpdateOn { get; set; } = DateTime.Now;
        public int LastUpdateBy { get; set; }
    }
}