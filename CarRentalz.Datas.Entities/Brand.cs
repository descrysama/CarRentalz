using System;
using System.Collections.Generic;

namespace CarRentalz.Datas.Entities;

public partial class Brand
{
    public int Id { get; set; }

    public string BrandName { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
