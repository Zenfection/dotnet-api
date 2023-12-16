using System;
using System.Collections.Generic;

namespace dotnet_api.Models.Domain;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string UrlHandle { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
