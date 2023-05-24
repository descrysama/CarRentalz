using System;
using System.Collections.Generic;

namespace CarRentalz.Datas.Entities;

public partial class Car
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int AgencyId { get; set; }

    public int BrandId { get; set; }

    public string Model { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual Agency Agency { get; set; } = null!;

    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<CarRating> CarRatings { get; set; } = new List<CarRating>();

    public virtual ICollection<CarSetting> CarSettings { get; set; } = new List<CarSetting>();

    public virtual ICollection<Rent> Rents { get; set; } = new List<Rent>();

    public virtual User User { get; set; } = null!;
}
