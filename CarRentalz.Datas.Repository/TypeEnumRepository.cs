using System;
using CarRentalz.Datas.Repository.Contract;
using CarRentalz.Datas.Entities;
using CarRentalz.Datas.CarRentalzDbContextNameSpace;

namespace CarRentalz.Datas.Repository
{
    public class TypeEnumRepository : GenericRepository<TypeEnum>, ITypeEnumRepository
    {
        public TypeEnumRepository(CarRentalzDbContext carRentalzDbContext) : base(carRentalzDbContext)
        {

        }
    }
}

