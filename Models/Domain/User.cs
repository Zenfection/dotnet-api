namespace API.Models.Domain;

public partial class User : BaseEntity
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public string? Name { get; set; }

    public ICollection<Post> Posts { get; set; } = new List<Post>();
}
