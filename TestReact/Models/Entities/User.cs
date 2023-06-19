using System;
using System.Collections.Generic;

namespace TestReact.Models.Entities;

public partial class User
{
    public string Id { get; set; } = null!;

    public string Pseudo { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string Password { get; set; } = null!;

    public byte[]? Salt { get; set; }

    public DateTime? RegistrationDate { get; set; }
}
