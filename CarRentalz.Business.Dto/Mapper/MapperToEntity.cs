using System;
using CarRentalz.Business.Dto;
using CarRentalz.Datas.Entities;

namespace CarRentalz.Business.Dto.Mapper
{
    public class MapperToEntity
	{
        public static User CreateUser(CreateUserDto createUserDto)
        {
             User user = new User()
                {
                    Email = createUserDto.Email,
                    Password = createUserDto.Password,
                    Pseudo = createUserDto.Pseudo,
                    ProfilePicture = createUserDto.ProfilePicture
                };

            return user;
        }

    }
}

