using System;
using System.Collections.Generic;

namespace CarRentalz.Datas.Entities;

public partial class Agency
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
