using System;
using System.Collections.Generic;

namespace CarRentalz.Datas.Entities;

public partial class FuelEnum
{
    public int Id { get; set; }

    public string Value { get; set; } = null!;

    public virtual ICollection<CarSetting> CarSettings { get; set; } = new List<CarSetting>();
}
