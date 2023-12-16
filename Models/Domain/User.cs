using System;
using System.Collections.Generic;

namespace dotnet_api.Models.Domain;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string? Name { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
