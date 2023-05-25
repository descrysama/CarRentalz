using System;
using CarRentalz.Datas.Repository.Contract;
using CarRentalz.Datas.Entities;
using CarRentalz.Datas.CarRentalzDbContextNameSpace;

namespace CarRentalz.Datas.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(CarRentalzDbContext carRentalzDbContext) : base(carRentalzDbContext)
        {

        }
    }
}

