namespace API.Models.DTO
{
    public class CreatePostDto
    {
        public string Title { get; set; } = null!;

        public string Content { get; set; } = null!;

        public string ShortDescription { get; set; } = null!;

        public string UrlHandle { get; set; } = null!;

        public bool IsVisible { get; set; } = true;


        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public Guid Author { get; set; }

        public Guid[] CategoriesId { get; set; } = null!;
    }
}