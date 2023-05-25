using System;
namespace CarRentalz.Business.Dto
{
	public class UserReadDto
	{
        public int Id { get; set; }

        public string Pseudo { get; set; }

        public string Email { get; set; }

        public string ProfilePicture { get; set; }

    }
}

