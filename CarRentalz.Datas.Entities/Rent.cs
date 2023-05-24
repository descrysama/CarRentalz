using System;
using System.Collections.Generic;

namespace CarRentalz.Datas.Entities;

public partial class Rent
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int CarId { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime EndingDate { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
