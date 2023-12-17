namespace API.Models.Domain;

public partial class Post : BaseEntity
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string ShortDescription { get; set; } = null!;

    public string UrlHandle { get; set; } = null!;

    public bool IsVisible { get; set; }

    public User Author { get; set; } = null!;

    public List<Category> Categories { get; set; } = [];
}
