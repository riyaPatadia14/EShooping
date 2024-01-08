using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
namespace DataAccessLayer.GenericRepo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EShoppingDbContext _eShoppingDbContext;
        public GenericRepository(EShoppingDbContext eShoppingDbContext)
        {
            _eShoppingDbContext = eShoppingDbContext;
        }
        public async Task Add(T obj)
        {
            try
            {
                _eShoppingDbContext.Set<T>().Add(obj);
                await SaveChangeData();
                _eShoppingDbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task Delete(T obj)
        {
            try
            {
                _eShoppingDbContext.Set<T>().Find(obj);
                _eShoppingDbContext.Set<T>().Remove(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IList<T>> GetAll()
        {
            try
            {
                return await _eShoppingDbContext.Set<T>().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public T GetbyId(object id)
        {
            try
            {
                return _eShoppingDbContext.Set<T>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task Update(T obj)
        {
            try
            {
                _eShoppingDbContext.Set<T>().Attach(obj);
                _eShoppingDbContext.Entry(obj).State = EntityState.Modified;
                SaveChangeData();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> SaveChangeData()
        {
            try
            {
                foreach (var item in _eShoppingDbContext.ChangeTracker.Entries())
                {
                    var now = DateTime.Now;
                    var modelBase = item.Entity as BaseEntity;
                    if (modelBase != null)
                    {
                        switch (item.State)
                        {
                            case EntityState.Added:
                                modelBase.CreatedDate = now;
                                goto case EntityState.Modified;
                            case EntityState.Modified:
                                modelBase.ModifiedDate = now;
                                break;
                            default:
                                break;
                        }
                    }
                }
                return _eShoppingDbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
