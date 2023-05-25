using System;
using CarRentalz.Datas.Repository.Contract;
using CarRentalz.Datas.Entities;
using CarRentalz.Datas.CarRentalzDbContextNameSpace;

namespace CarRentalz.Datas.Repository
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        public AdminRepository(CarRentalzDbContext carRentalzDbContext) : base(carRentalzDbContext)
        {

        }
    }
}

