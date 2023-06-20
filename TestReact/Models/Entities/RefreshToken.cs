using System;
using System.Collections.Generic;

namespace TestReact.Models.Entities;

public partial class RefreshToken
{
    public int Id { get; set; }

    public string Token { get; set; } = null!;

    public string Username { get; set; } = null!;

    public DateTime Date { get; set; }
}
