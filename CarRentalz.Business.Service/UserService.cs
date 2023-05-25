using System;
using CarRentalz.Datas.Repository.Contract;

namespace CarRentalz.Business.Service
{
	public class UserService
	{
		private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
        }


	}
}

