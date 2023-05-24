using System;
using System.Collections.Generic;

namespace CarRentalz.Datas.Entities;

public partial class CarRating
{
    public int Id { get; set; }

    public int CarId { get; set; }

    public int NoteValue { get; set; }

    public string? Message { get; set; }

    public virtual Car Car { get; set; } = null!;
}
