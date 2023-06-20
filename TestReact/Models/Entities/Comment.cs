﻿using System;
using System.Collections.Generic;

namespace TestReact.Models.Entities;

public partial class Comment
{
    public int? Id { get; set; }

    public int Article { get; set; }

    public string Pseudo { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime? Date { get; set; }
}
