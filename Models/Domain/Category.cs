namespace API.Models.Domain;

public partial class Category : BaseEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string UrlHandle { get; set; } = null!;

    public ICollection<Post> Posts { get; set; } = new List<Post>();
}
