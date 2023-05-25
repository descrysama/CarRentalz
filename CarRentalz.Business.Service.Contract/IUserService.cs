using System;
using CarRentalz.Datas.Entities;
using CarRentalz.Business.Dto;

namespace CarRentalz.Business.Service.Contract
{
	public interface IUserService
	{
        Task<IEnumerable<User>> FindAll();
        Task<UserReadDto> createUser(CreateUserDto userToCreate);
    }
}

