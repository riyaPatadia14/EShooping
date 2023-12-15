namespace DataAccessLayer.GenericRepo
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> GetAll();
        Task Add(T obj);
        Task Update(T obj);
        T GetbyId(object id);
        Task Delete(T obj);
    }
}
