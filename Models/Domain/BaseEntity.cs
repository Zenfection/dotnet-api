namespace API.Models.Domain
{
    public abstract class BaseEntity
    {
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}
