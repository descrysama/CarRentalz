using CarRentalz.Datas.CarRentalzDbContextNameSpace;
using CarRentalz.Datas.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace CarRentalz.Datas.Repository
{
	public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly CarRentalzDbContext _CarRentalzDbContext;

        private readonly DbSet<T> _table;

        protected GenericRepository(CarRentalzDbContext CarRentalzDbContext)
        {
            _CarRentalzDbContext = CarRentalzDbContext;
            _table = _CarRentalzDbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _table.ToListAsync().ConfigureAwait(false);
        }

        public async Task<T> GetById(object id)
        {
            T element = await _table.FindAsync(id).ConfigureAwait(false);

            if (element == null)
            {
                throw new Exception("Element non trouvé.");
            }

            return element;
        }

        public async Task<T> Insert(T element)
        {
            var elementAdded = await _table.AddAsync(element).ConfigureAwait(false);
            await _CarRentalzDbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementAdded.Entity;
        }

        public async Task<T> Update(T element)
        {
            var elementUpdated = _table.Update(element);
            await _CarRentalzDbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementUpdated.Entity;
        }

        public async Task<T> Delete(T element)
        {
            var elementDeleted = _table.Remove(element);
            await _CarRentalzDbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementDeleted.Entity;
        }


    }
}

