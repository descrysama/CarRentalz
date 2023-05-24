using System;
using System.Collections.Generic;

namespace CarRentalz.Datas.Entities;

public partial class Admin
{
    public int Id { get; set; }

    public string Pseudo { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? ProfilePicture { get; set; }

    public int AdminGradeId { get; set; }

    public virtual AdminGrade AdminGrade { get; set; } = null!;
}
