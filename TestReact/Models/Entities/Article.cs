using System;
using System.Collections.Generic;

namespace TestReact.Models.Entities;

public partial class Article
{
    public int Id { get; set; }

    public string Author { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime Date { get; set; }
}
