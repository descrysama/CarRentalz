using System;
using CarRentalz.Datas.Repository.Contract;
using CarRentalz.Datas.Entities;
using CarRentalz.Datas.CarRentalzDbContextNameSpace;

namespace CarRentalz.Datas.Repository
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(CarRentalzDbContext carRentalzDbContext) : base(carRentalzDbContext)
        {

        }
    }
}

