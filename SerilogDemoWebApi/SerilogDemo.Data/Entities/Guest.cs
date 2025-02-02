using System;
using System.Collections.Generic;

namespace SerilogDemo.Data.Entities;

public partial class Guest
{
    public Guid Id { get; set; }

    public int Title { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string Email { get; set; } = null!;

    public string? PhoneNumbers { get; set; }
}
