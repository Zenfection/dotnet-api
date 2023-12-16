using System;
using System.Collections.Generic;

namespace dotnet_api.Models.Domain;

public partial class Post
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string ShortDescription { get; set; } = null!;

    public string UrlHandle { get; set; } = null!;

    public bool IsVisible { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int AuthorId { get; set; }

    public int? CategoryId { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual Category? Category { get; set; }
}
