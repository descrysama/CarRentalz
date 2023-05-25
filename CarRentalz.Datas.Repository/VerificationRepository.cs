using System;
using CarRentalz.Datas.Repository.Contract;
using CarRentalz.Datas.Entities;
using CarRentalz.Datas.CarRentalzDbContextNameSpace;

namespace CarRentalz.Datas.Repository
{
	public class VerificationRepository: GenericRepository<Verification>, IVerificationRepository
	{
		public VerificationRepository(CarRentalzDbContext carRentalzDbContext): base(carRentalzDbContext)
		{

		}
	}
}

