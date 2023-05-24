using System;
using System.Collections.Generic;

namespace CarRentalz.Datas.Entities;

public partial class UserRating
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int NoteValue { get; set; }

    public string? Message { get; set; }

    public virtual User User { get; set; } = null!;
}
