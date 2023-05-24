using System;
namespace CarRentalz.Datas.Repository.Contract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(object id);

        Task<T> Insert(T element);

        Task<T> Update(T element);

        Task<T> Delete(T element);
    }

}

