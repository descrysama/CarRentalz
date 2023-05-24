using System;
using System.Collections.Generic;

namespace CarRentalz.Datas.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Pseudo { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? ProfilePicture { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Rent> Rents { get; set; } = new List<Rent>();

    public virtual ICollection<UserRating> UserRatings { get; set; } = new List<UserRating>();

    public virtual ICollection<Verification> Verifications { get; set; } = new List<Verification>();
}
