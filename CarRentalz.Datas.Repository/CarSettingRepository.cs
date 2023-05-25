using System;
using CarRentalz.Datas.Repository.Contract;
using CarRentalz.Datas.Entities;
using CarRentalz.Datas.CarRentalzDbContextNameSpace;

namespace CarRentalz.Datas.Repository
{
    public class CarSettingRepository : GenericRepository<CarSetting>, ICarSettingRepository
    {
        public CarSettingRepository(CarRentalzDbContext carRentalzDbContext) : base(carRentalzDbContext)
        {

        }
    }
}

