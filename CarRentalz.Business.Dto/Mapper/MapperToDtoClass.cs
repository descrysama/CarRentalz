using System;
using CarRentalz.Datas.Entities;

namespace CarRentalz.Business.Dto.Mapper
{
	public class MapperToDtoClass
	{
        public static UserReadDto CreateUser(User UserEntity)
        {
            UserReadDto user = new UserReadDto()
            {
                Id = UserEntity.Id,
                Email = UserEntity.Email,
                Pseudo = UserEntity.Pseudo,
                ProfilePicture = UserEntity.ProfilePicture
            };

            return user;
        }
    }
}

