using System;
using CarRentalz.Datas.Entities;
using CarRentalz.Datas.Repository.Contract;
using CarRentalz.Business.Dto;
using CarRentalz.Business.Dto.Mapper;
using CarRentalz.Business.Service.Contract;

namespace CarRentalz.Business.Service
{
	public class UserService: IUserService
    {
		private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
        }


        public async Task<IEnumerable<User>> FindAll()
        {
            IEnumerable<User> user = await _userRepository.GetAll().ConfigureAwait(false);

            return user;

        }

        public async Task<UserReadDto> createUser(CreateUserDto userToCreate)
        {
            User userEntity = MapperToEntity.CreateUser(userToCreate);

            User user = await _userRepository.Insert(userEntity).ConfigureAwait(false);

            UserReadDto userDto = MapperToDtoClass.CreateUser(user);

            return userDto;

        }
    }
}

