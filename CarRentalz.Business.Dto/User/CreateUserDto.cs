﻿using System;
namespace CarRentalz.Business.Dto
{
	public class CreateUserDto
	{
        public string Pseudo { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string? ProfilePicture { get; set; }
    }
}

