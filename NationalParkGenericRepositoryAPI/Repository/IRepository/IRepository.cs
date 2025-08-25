namespace NationalParkGenericRepositoryAPI.Repository.IRepository
{
        public interface IRepository<T> where T : class
        {
        ICollection<T> GetAll();
        T Get(int id);
        bool Exists(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Save();
    }



    
}
