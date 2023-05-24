using System;
using System.Collections.Generic;

namespace CarRentalz.Datas.Entities;

public partial class TypeEnum
{
    public int Id { get; set; }

    public string Value { get; set; } = null!;

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
