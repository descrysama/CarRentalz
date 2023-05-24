using System;
using System.Collections.Generic;

namespace CarRentalz.Datas.Entities;

public partial class AdminGrade
{
    public int Id { get; set; }

    public string Value { get; set; } = null!;

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();
}
