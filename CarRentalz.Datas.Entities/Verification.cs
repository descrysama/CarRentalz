using System;
using System.Collections.Generic;

namespace CarRentalz.Datas.Entities;

public partial class Verification
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int Status { get; set; }

    public virtual User User { get; set; } = null!;
}
