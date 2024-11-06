using System;
using System.Collections.Generic;

namespace Webpro.Models;

public partial class User
{
    public string? Namesurname { get; set; }

    public string Username { get; set; } = null!;

    public string? Password { get; set; }
}
