using System;
using System.Collections.Generic;

namespace CarRentalz.Datas.Entities;

public partial class Notification
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int TypeId { get; set; }

    public string Message { get; set; } = null!;

    public virtual TypeEnum Type { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
