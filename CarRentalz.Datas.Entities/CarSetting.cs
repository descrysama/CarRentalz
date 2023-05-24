using System;
using System.Collections.Generic;

namespace CarRentalz.Datas.Entities;

public partial class CarSetting
{
    public int Id { get; set; }

    public int CarId { get; set; }

    public float DailyCost { get; set; }

    public int AllowedKilometers { get; set; }

    public int GearboxId { get; set; }

    public int FuelId { get; set; }

    public bool AirConditioning { get; set; }

    public int DrivingAssist { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual FuelEnum Fuel { get; set; } = null!;

    public virtual GearboxEnum Gearbox { get; set; } = null!;
}
